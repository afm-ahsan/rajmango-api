using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RajMango.Domain.Common;
using System.Linq.Expressions;
using System.Reflection;

namespace RajMango.DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Restrict cascade delete behavior for all foreign keys pointing to TEntity.
        /// Prevents SQL Server multiple cascade path errors.
        /// </summary>
        /// Restrict cascade delete for a specific principal entity
        public static void RestrictCascadeDeleteFor<TEntity>(this ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                if (foreignKey.PrincipalEntityType.ClrType == typeof(TEntity) &&
                    foreignKey.DeleteBehavior == DeleteBehavior.Cascade)
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }

        /// Restrict all cascade delete for principal entity
        public static void RestrictAllCascadeDeletes(this ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                if (foreignKey.DeleteBehavior == DeleteBehavior.Cascade)
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }


        /// Apply global decimal precision (e.g., decimal(18,2)) across all properties
        public static void ApplyGlobalDecimalPrecision(this ModelBuilder modelBuilder, int precision = 18, int scale = 2)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
                {
                    property.SetPrecision(precision);
                    property.SetScale(scale);
                }
            }
        }

        /// Apply HasColumnOrder so business columns appear in C# declaration order and audit
        /// columns are pinned at the end (CreatedAt=900 … IsDeleted=906).
        ///
        /// Why both need explicit orders:
        ///   EF Core sorts columns by HasColumnOrder, treating absent annotation as int.MaxValue.
        ///   Any explicit value (e.g. 900) sorts BEFORE int.MaxValue, so audit-only ordering
        ///   puts audit FIRST. Business columns must get explicit low values (1, 2, 3 …) to
        ///   appear before 900–906.
        ///
        /// Why entityType.GetProperties() cannot be used for business column order:
        ///   EF Core returns its internal metadata in alphabetical order, not C# source order.
        ///   Reflection with BindingFlags.DeclaredOnly gives properties in their actual
        ///   declaration order and is used here to walk the class hierarchy (base → derived),
        ///   skipping the known audit base classes whose fields are handled separately.
        public static void ApplyAuditColumnOrdering(this ModelBuilder modelBuilder)
        {
            var auditOrders = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [nameof(ICreationAuditable.CreatedAt)] = 900,
                [nameof(ICreationAuditable.CreatedBy)] = 901,
                [nameof(IAuditable.UpdatedAt)]         = 902,
                [nameof(IAuditable.UpdatedBy)]         = 903,
                [nameof(IFullAuditable.DeletedAt)]     = 904,
                [nameof(IFullAuditable.DeletedBy)]     = 905,
                [nameof(ISoftDelete.IsDeleted)]        = 906,
            };

            // Audit base class types whose declared properties are the audit columns above.
            // Their own GetProperties(DeclaredOnly) results are skipped during business-column
            // discovery so audit fields are not also treated as business columns.
            var auditBaseTypes = new HashSet<Type>
            {
                typeof(FullAuditedEntity),
                typeof(AuditedEntity),
                typeof(CreationAuditedEntity),
            };

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                bool isFullAudited   = typeof(IFullAuditable).IsAssignableFrom(clrType);
                bool isAudited       = typeof(IAuditable).IsAssignableFrom(clrType);
                bool isCreationAudit = typeof(ICreationAuditable).IsAssignableFrom(clrType);

                if (!isFullAudited && !isAudited && !isCreationAudit)
                    continue;

                var builder = modelBuilder.Entity(clrType);

                // Only the scalar properties EF Core actually maps (excludes navigations,
                // [NotMapped] properties, and shadow-only columns we do not control).
                var efMapped = entityType.GetProperties()
                    .Select(p => p.Name)
                    .ToHashSet(StringComparer.Ordinal);

                // Walk the class hierarchy (root → leaf) using BindingFlags.DeclaredOnly
                // so that properties come out in their C# source declaration order.
                var businessProps = GetBusinessPropertiesInDeclarationOrder(
                    clrType, auditBaseTypes, auditOrders, efMapped);

                // Assign sequential low orders so business columns sort before 900–906.
                for (int i = 0; i < businessProps.Count; i++)
                    builder.Property(businessProps[i]).HasColumnOrder(i + 1);

                // Pin audit columns at the end.
                if (isFullAudited)
                {
                    builder.Property(nameof(IFullAuditable.CreatedAt)).HasColumnOrder(900);
                    builder.Property(nameof(IFullAuditable.CreatedBy)).HasColumnOrder(901);
                    builder.Property(nameof(IFullAuditable.UpdatedAt)).HasColumnOrder(902);
                    builder.Property(nameof(IFullAuditable.UpdatedBy)).HasColumnOrder(903);
                    builder.Property(nameof(IFullAuditable.DeletedAt)).HasColumnOrder(904);
                    builder.Property(nameof(IFullAuditable.DeletedBy)).HasColumnOrder(905);
                    builder.Property(nameof(ISoftDelete.IsDeleted)).HasColumnOrder(906);
                }
                else if (isAudited)
                {
                    builder.Property(nameof(IAuditable.CreatedAt)).HasColumnOrder(900);
                    builder.Property(nameof(IAuditable.CreatedBy)).HasColumnOrder(901);
                    builder.Property(nameof(IAuditable.UpdatedAt)).HasColumnOrder(902);
                    builder.Property(nameof(IAuditable.UpdatedBy)).HasColumnOrder(903);
                }
                else // isCreationAudit
                {
                    builder.Property(nameof(ICreationAuditable.CreatedAt)).HasColumnOrder(900);
                    builder.Property(nameof(ICreationAuditable.CreatedBy)).HasColumnOrder(901);
                }
            }
        }

        /// Returns mapped scalar property names in C# source declaration order by walking
        /// the class hierarchy from most-base to most-derived, skipping audit base classes.
        /// BindingFlags.DeclaredOnly ensures only properties from that specific class level
        /// are returned, preserving their source-file declaration order (CLR guarantee).
        private static List<string> GetBusinessPropertiesInDeclarationOrder(
            Type clrType,
            HashSet<Type> auditBaseTypes,
            Dictionary<string, int> auditOrders,
            HashSet<string> efMapped)
        {
            // Collect hierarchy root-first, skipping audit base classes.
            var hierarchy = new List<Type>();
            for (var t = clrType; t != null && t != typeof(object); t = t.BaseType)
            {
                if (!auditBaseTypes.Contains(t))
                    hierarchy.Insert(0, t);
            }

            var result = new List<string>();
            var seen   = new HashSet<string>(StringComparer.Ordinal);

            foreach (var type in hierarchy)
            {
                foreach (var prop in type.GetProperties(
                    BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
                {
                    var name = prop.Name;
                    // Include only: not an audit column, mapped by EF Core, not yet added.
                    if (!auditOrders.ContainsKey(name) && efMapped.Contains(name) && seen.Add(name))
                        result.Add(name);
                }
            }

            return result;
        }

        /// Apply global query filters for soft-delete support (if using ISoftDelete marker)
        public static void ApplySoftDeleteQueryFilter(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Check if entity implements ISoftDelete
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
                    var compare = Expression.Equal(property, Expression.Constant(false));
                    var lambda = Expression.Lambda(compare, parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }
        }

        /// Apply global query filters for soft-delete support (if using IFullAuditable marker)
        public static void ApplySoftDeleteQueryFilter2(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IFullAuditable).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter, nameof(IFullAuditable.IsDeleted));
                    var filter = Expression.Equal(property, Expression.Constant(false));
                    var lambda = Expression.Lambda(filter, parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }
        }
    }
}

