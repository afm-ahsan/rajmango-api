using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RajMango.Domain.Common;
using System.Linq.Expressions;

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

