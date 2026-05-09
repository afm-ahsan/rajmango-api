using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.DataAccess.Extensions;
using RajMango.Domain.Entities;

namespace RajMango.DataAccess.Contexts
{
    public class AppDbContext : DbContext, IDataContext
    {
        private readonly ICurrentUserService _currentUserService;
        //private readonly AuditInterceptor _auditInterceptor; //TODO: Audit Logging
        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
            //_auditInterceptor = auditInterceptor;
        }

        // 🔐 Identity & User Management
        public virtual DbSet<AppUser> Users => Set<AppUser>();
        public virtual DbSet<Role> Roles => Set<Role>();
        public virtual DbSet<UserRole> UserRoles => Set<UserRole>();
        public virtual DbSet<JwtAuth> JwtAuths => Set<JwtAuth>();
        public virtual DbSet<UserAddress> UserAddresses => Set<UserAddress>();
        public virtual DbSet<Customer> Customers => Set<Customer>();

        // 📦 Product Catalog & Types
        public virtual DbSet<Category> Categories => Set<Category>();
        public virtual DbSet<Product> Products => Set<Product>();
        public virtual DbSet<MangoType> MangoTypes => Set<MangoType>();

        // 🛒 Orders & Payments
        public virtual DbSet<Order> Orders => Set<Order>();
        public virtual DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        public virtual DbSet<Payment> Payments => Set<Payment>();
        public virtual DbSet<PaymentAttachment> PaymentAttachments => Set<PaymentAttachment>();
        public virtual DbSet<Refund> Refunds => Set<Refund>();

        // 💰 Expenses
        public virtual DbSet<ExpenseType> ExpenseTypes => Set<ExpenseType>();
        public virtual DbSet<Expense> Expenses => Set<Expense>();
        public virtual DbSet<ExpenseAttachment> ExpenseAttachments => Set<ExpenseAttachment>();

        // 🚚 Courier & Logistics
        public virtual DbSet<CourierProvider> CourierProviders => Set<CourierProvider>();
        public virtual DbSet<CourierStation> CourierStations => Set<CourierStation>();
        public virtual DbSet<CourierAreaMap> CourierAreaMaps => Set<CourierAreaMap>();

        // 💬 Feedback & Audit
        public virtual DbSet<Feedback> Feedbacks => Set<Feedback>();
        public virtual DbSet<AuditLog> AuditLogs => Set<AuditLog>();


        public virtual DbSet<TEntity> Get<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Apply entity configs from the same assembly as DbContext
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // 2. Apply global decimal(18,2) precision
            modelBuilder.ApplyGlobalDecimalPrecision();

            // 3. Seed system roles and user
            modelBuilder.LoadSystemLevelSeedData();
            modelBuilder.LoadOtherSeedData();

            // 4. Apply soft-delete query filters globally
            modelBuilder.ApplySoftDeleteQueryFilter();

            // 5. Prevent multiple cascade paths from Order
            modelBuilder.RestrictCascadeDeleteFor<Order>(); 
            //modelBuilder.RestrictAllCascadeDeletes();
        }

        //public override int SaveChanges()
        //{
        //    AuditingHelper.ApplyAuditing(ChangeTracker, _currentUserService);
        //    return base.SaveChanges();
        //}

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    AuditingHelper.ApplyAuditing(ChangeTracker, _currentUserService);
        //    return await base.SaveChangesAsync(cancellationToken);
        //}
    }
}
