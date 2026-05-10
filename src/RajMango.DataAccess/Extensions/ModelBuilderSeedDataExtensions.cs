using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using System.Text.Json;

namespace RajMango.DataAccess.Extensions
{
    public static class ModelBuilderSeedDataExtensions
    {
        public static void LoadSystemLevelSeedData(this ModelBuilder modelBuilder)
        {
            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "System Admin",
                    Code = "system_admin",
                    Description = "Full system access including user and role management.",
                    PermissionJson = JsonSerializer.Serialize(new List<string> { "ALL" }),
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedAt = Clock.Now()
                },
                new Role
                {
                    Id = 2,
                    Name = "Admin",
                    Code = "admin",
                    Description = "Standard administrative access excluding system-level configurations.",
                    PermissionJson = JsonSerializer.Serialize(new List<string> { "ManageUsers", "ManageOrders", "ViewReports" }),
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedAt = Clock.Now()
                },
                new Role
                {
                    Id = 3,
                    Name = "General",
                    Code = "general",
                    Description = "Standard user like a customer access only order related features",
                    PermissionJson = JsonSerializer.Serialize(new List<string> { "ManageOrders", "ViewReports" }),
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedAt = Clock.Now()
                }
            );

            // Seed System Admin User
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "SA1000",
                    FirstName = "System",
                    LastName = "Admin",
                    PhoneNumber = "01700000000",
                    PhoneNumberConfirmed = true,
                    Email = "systemadmin@rajmango.com",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "SysAdmin@1690#"),
                    AccessFailedCount = 0,
                    IsLocked = false,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedAt = Clock.Now()
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "AU2000",
                    FirstName = "Admin",
                    LastName = "User",
                    PhoneNumber = "01700000000",
                    PhoneNumberConfirmed = true,
                    Email = "admin@rajmango.com",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Admin@1690#"),
                    AccessFailedCount = 0,
                    IsLocked = false,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedAt = Clock.Now()
                },
                new AppUser
                {
                    Id = 3,
                    UserName = "GU3000",
                    FirstName = "General",
                    LastName = "User",
                    PhoneNumber = "01700000000",
                    PhoneNumberConfirmed = true,
                    Email = "general@rajmango.com",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "General@1690#"),
                    AccessFailedCount = 0,
                    IsLocked = false,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedAt = Clock.Now()
                }
            );

            // Assign Role to User
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = 1,
                    CreatedBy = 1,
                    CreatedAt = Clock.Now(),
                    AssignedAt = Clock.Now()
                },
                new UserRole
                {
                    Id = 2,
                    UserId = 2,
                    RoleId = 2,
                    CreatedBy = 1,
                    CreatedAt = Clock.Now(),
                    AssignedAt = Clock.Now()
                },
                new UserRole
                {
                    Id = 3,
                    UserId = 3,
                    RoleId = 3,
                    CreatedBy = 1,
                    CreatedAt = Clock.Now(),
                    AssignedAt = Clock.Now()
                }
            );
        }

        public static void LoadOtherSeedData(this ModelBuilder modelBuilder)
        {
            // Seed MangoTypes
            modelBuilder.Entity<MangoType>().HasData(
                new MangoType
                {
                    Id = 1,
                    Name = "Gopalbhog",
                    Description = "A sweet and early-season mango, Gopalbhog is known for its rich aroma, fiberless flesh, and vibrant yellow skin. Popular in Rajshahi and Chapainawabganj.",
                    ImagePath = "/uploads/mango-types/2026/05/mango-type-1-gopalbhog.jpg",
                    Sequence = 1,
                    Region = "Rajshahi",
                    AverageWeight = "250-350g",
                    MangoGrade = MangoGrade.Premium,
                    SweetnessLevel = SweetnessLevel.VeryHigh,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                },
            new MangoType
            {
                Id = 2,
                Name = "Himsagor",
                Description = "Also known as Khirshapat, this premium mango is highly sought after for its buttery smooth texture and excellent sweetness. It’s the pride of Chapainawabganj.",
                ImagePath = "/uploads/mango-types/2026/05/mango-type-2-himsagor.jpg",
                Sequence = 2,
                Region = "Chapainawabganj",
                AverageWeight = "300-400g",
                MangoGrade = MangoGrade.Premium,
                SweetnessLevel = SweetnessLevel.VeryHigh,
                CreatedAt = DateTime.Now,
                CreatedBy = 1
            },
            new MangoType
            {
                Id = 3,
                Name = "Langra",
                Description = "Langra is a traditional mid-season mango with a distinct tangy-sweet taste. Its green skin remains even when ripe. Highly popular across Bangladesh.",
                ImagePath = "/uploads/mango-types/2026/05/mango-type-3-langra.jpg",
                Sequence = 3,
                Region = "Rajshahi",
                AverageWeight = "300-500g",
                MangoGrade = MangoGrade.Standard,
                SweetnessLevel = SweetnessLevel.High,
                CreatedAt = DateTime.Now,
                CreatedBy = 1
            },
            new MangoType
            {
                Id = 4,
                Name = "Amrupali",
                Description = "A hybrid mango known for its long shelf life and rich aroma. Amrupali is intensely sweet and has a reddish hue when ripe. Great for gifting and exports.",
                ImagePath = "/uploads/mango-types/2026/05/mango-type-4-amrupali.jpg",
                Sequence = 4,
                Region = "Rajshahi",
                AverageWeight = "200-300g",
                MangoGrade = MangoGrade.Premium,
                SweetnessLevel = SweetnessLevel.High,
                CreatedAt = DateTime.Now,
                CreatedBy = 1
            },
            new MangoType
            {
                Id = 5,
                Name = "Brindabon",
                Description = "A local variety with good sweetness and juiciness, Brindabon mangoes are medium-sized and ideal for table consumption. Rarely found outside local markets.",
                ImagePath = "/uploads/mango-types/2026/05/mango-type-5-brindabon.jpg",
                Sequence = 5,
                Region = "Brindabonpur",
                AverageWeight = "250-350g",
                MangoGrade = MangoGrade.Standard,
                SweetnessLevel = SweetnessLevel.Medium,
                CreatedAt = DateTime.Now,
                CreatedBy = 1
            },
            new MangoType
            {
                Id = 6,
                Name = "Fazli",
                Description = "Fazli mangoes are large, fleshy, and less fibrous, making them perfect for pulp and chutney. They are harvested late in the season and have excellent storage qualities.",
                ImagePath = "/uploads/mango-types/2026/05/mango-type-6-fazli.jpg",
                Sequence = 6,
                Region = "Rajshahi",
                AverageWeight = "500-700g",
                MangoGrade = MangoGrade.Standard,
                SweetnessLevel = SweetnessLevel.Medium,
                CreatedAt = DateTime.Now,
                CreatedBy = 1
            });
        }

        public static void LoadCourierProviderSeedData(this ModelBuilder modelBuilder)
        {
            // Courier Provider Seed 
            modelBuilder.Entity<CourierProvider>().HasData(
                new CourierProvider { Id = 1, Name = "Ahmed Parcel Service", SupportPhone = "01710000001", Sequence = 1, IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierProvider { Id = 2, Name = "Janani Courier Service", SupportPhone = "01710000002", Sequence = 2, IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierProvider { Id = 3, Name = "Karatoa Courier Service", SupportPhone = "01710000003", Sequence = 3, IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierProvider { Id = 4, Name = "SR Parcel Services Ltd.", SupportPhone = "01710000004", Sequence = 4, IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierProvider { Id = 5, Name = "Shodagor Express Limited", SupportPhone = "01710000005", Sequence = 5, IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierProvider { Id = 6, Name = "SB Courier Service", SupportPhone = "01710000006", Sequence = 6, IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierProvider { Id = 7, Name = "SA Paribahan", SupportPhone = "01710000007", Sequence = 7, IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierProvider { Id = 8, Name = "Sundarban Courier", SupportPhone = "01710000008", Sequence = 8, IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 }
            );
        }

        public static void LoadCourierStationSeedData(this ModelBuilder modelBuilder)
        {
            // Courier Station Seed 
            modelBuilder.Entity<CourierStation>().HasData(
                new CourierStation { Id = 1, CourierProviderId = 1, Name = "Ahmed - Dhanmondi Branch", AddressLine = "Satmasjid Road", City = "Dhaka", Area = "Dhanmondi", SupportPhone1 = "01720000001", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierStation { Id = 2, CourierProviderId = 2, Name = "Janani - Mirpur 10", AddressLine = "Pallabi, Mirpur 10", City = "Dhaka", Area = "Mirpur", SupportPhone1 = "01720000002", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierStation { Id = 3, CourierProviderId = 3, Name = "Karatoa - Banani", AddressLine = "Banani Block C", City = "Dhaka", Area = "Banani", SupportPhone1 = "01720000003", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierStation { Id = 4, CourierProviderId = 4, Name = "SR - Gulshan 2", AddressLine = "Gulshan Circle 2", City = "Dhaka", Area = "Gulshan 2", SupportPhone1 = "01720000004", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierStation { Id = 5, CourierProviderId = 5, Name = "Shodagor - Kawran Bazar", AddressLine = "Near T&T Market", City = "Dhaka", Area = "Kawran Bazar", SupportPhone1 = "01720000005", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierStation { Id = 6, CourierProviderId = 6, Name = "SB - Mohakhali", AddressLine = "Opposite Bus Terminal", City = "Dhaka", Area = "Mohakhali", SupportPhone1 = "01720000006", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierStation { Id = 7, CourierProviderId = 7, Name = "SA - Gulistan", AddressLine = "Gulistan Underpass", City = "Dhaka", Area = "Gulistan", SupportPhone1 = "01720000007", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierStation { Id = 8, CourierProviderId = 8, Name = "Sundarban - New Market", AddressLine = "Gate 1", City = "Dhaka", Area = "New Market", SupportPhone1 = "01720000008", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierStation { Id = 9, CourierProviderId = 7, Name = "SA - Malibagh", AddressLine = "Malibagh Crossing", City = "Dhaka", Area = "Malibagh", SupportPhone1 = "01720000009", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierStation { Id = 10, CourierProviderId = 8, Name = "Sundarban - Uttara", AddressLine = "Sector 7", City = "Dhaka", Area = "Uttara", SupportPhone1 = "01720000010", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierStation { Id = 11, CourierProviderId = 6, Name = "SB - Gazipur", AddressLine = "Chowrasta", City = "Gazipur", Area = "Gazipur", SupportPhone1 = "01720000011", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierStation { Id = 12, CourierProviderId = 5, Name = "Shodagor - Gulshan 1", AddressLine = "Gulshan 1 Circle", City = "Dhaka", Area = "Gulshan 1", SupportPhone1 = "01720000012", IsActive = true, CreatedAt = Clock.Now(), CreatedBy = 1 }
            );
        }

        public static void LoadCourierAreaMapSeedData(this ModelBuilder modelBuilder)
        {
            // Courier Area Map Seed 
            modelBuilder.Entity<CourierAreaMap>().HasData(
                new CourierAreaMap { Id = 1, CourierStationId = 1, Area = "Dhanmondi", CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierAreaMap { Id = 2, CourierStationId = 2, Area = "Mirpur", CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierAreaMap { Id = 3, CourierStationId = 3, Area = "Banani", CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierAreaMap { Id = 4, CourierStationId = 4, Area = "Gulshan 2", CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierAreaMap { Id = 5, CourierStationId = 5, Area = "Kawran Bazar", CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierAreaMap { Id = 6, CourierStationId = 6, Area = "Mohakhali", CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierAreaMap { Id = 7, CourierStationId = 7, Area = "Gulistan", CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierAreaMap { Id = 8, CourierStationId = 8, Area = "New Market", CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierAreaMap { Id = 9, CourierStationId = 9, Area = "Malibagh", CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierAreaMap { Id = 10, CourierStationId = 10, Area = "Uttara", CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierAreaMap { Id = 11, CourierStationId = 11, Area = "Gazipur", CreatedAt = Clock.Now(), CreatedBy = 1 },
                new CourierAreaMap { Id = 12, CourierStationId = 12, Area = "Gulshan 1", CreatedAt = Clock.Now(), CreatedBy = 1 }
            );
        }
    }
}
