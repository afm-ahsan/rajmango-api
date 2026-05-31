using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RajMango.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PerformedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PerformedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreviousData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourierProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupportPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaqItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MangoTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AverageWeight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MangoGrade = table.Column<int>(type: "int", nullable: false),
                    SweetnessLevel = table.Column<int>(type: "int", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangoTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderNumberCounters",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNumberCounters", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Module = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PermissionJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemRole = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JwtAuth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AuthToken = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedBy = table.Column<int>(type: "int", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeviceInfo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JwtAuth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JwtAuth_AppUsers_RevokedBy",
                        column: x => x.RevokedBy,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JwtAuth_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    WeightPerUnitKg = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OriginRegion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UnitType = table.Column<int>(type: "int", nullable: false),
                    IsSeasonal = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourierRateConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierProviderId = table.Column<int>(type: "int", nullable: false),
                    CourierLocationType = table.Column<int>(type: "int", nullable: false),
                    RatePerKg = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MinimumCharge = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierRateConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierRateConfigurations_CourierProviders_CourierProviderId",
                        column: x => x.CourierProviderId,
                        principalTable: "CourierProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourierStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierProviderId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupportPhone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SupportPhone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    GoogleMapUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierStations_CourierProviders_CourierProviderId",
                        column: x => x.CourierProviderId,
                        principalTable: "CourierProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentReference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaidTo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "ExpenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangoAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangoTypeId = table.Column<int>(type: "int", nullable: false),
                    SeasonYear = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePerKg = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangoAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MangoAvailabilities_MangoTypes_MangoTypeId",
                        column: x => x.MangoTypeId,
                        principalTable: "MangoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    IsGranted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => new { x.UserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserPermissions_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourierAreaMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierStationId = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierAreaMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierAreaMaps_CourierStations_CourierStationId",
                        column: x => x.CourierStationId,
                        principalTable: "CourierStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourierStationId = table.Column<int>(type: "int", nullable: true),
                    CourierProviderId = table.Column<int>(type: "int", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductTotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DueAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CourierLocationType = table.Column<int>(type: "int", nullable: true),
                    CourierRatePerKg = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CourierCharge = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CourierChargeOverrideAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IsCourierChargeOverridden = table.Column<bool>(type: "bit", nullable: false),
                    CourierChargeNote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    DeliveryStatus = table.Column<int>(type: "int", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    IsValidOrder = table.Column<bool>(type: "bit", nullable: false),
                    FallbackAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReceiverType = table.Column<int>(type: "int", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReceiverMobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DeliveryNote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_CourierProviders_CourierProviderId",
                        column: x => x.CourierProviderId,
                        principalTable: "CourierProviders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_CourierStations_CourierStationId",
                        column: x => x.CourierStationId,
                        principalTable: "CourierStations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpenseAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseAttachments_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AdminNote = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ResolvedBy = table.Column<int>(type: "int", nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Complaints_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MangoTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CrateType = table.Column<int>(type: "int", nullable: false),
                    IsGift = table.Column<bool>(type: "bit", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_MangoTypes_MangoTypeId",
                        column: x => x.MangoTypeId,
                        principalTable: "MangoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GrossAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    VatAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DueAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    GatewayPaymentId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GatewayTransactionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MerchantInvoiceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BkashCallbackStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RawCreateResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RawExecuteResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintImages_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedbackImages_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentAttachments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refunds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RefundDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefundReason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RefundedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefundReference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsGatewayRefunded = table.Column<bool>(type: "bit", nullable: false),
                    RefundStatus = table.Column<int>(type: "int", nullable: false),
                    GatewayResponseMessage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GatewayTransactionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refunds_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "EmailConfirmed", "FirstName", "ImagePath", "IsActive", "IsDeleted", "IsLocked", "LastName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2026, 5, 31, 23, 44, 39, 4, DateTimeKind.Unspecified).AddTicks(453), 1, null, 0, "sysadmin@rajmango.com", true, "System", null, true, false, false, "Admin", "AQAAAAIAAYagAAAAEPBMkA2oUS9nfWqVC0/0UU5uDsli6bwrVykv2DRntbqDcNQBmssE0ByAZ9Bhvd+lCA==", "+8801717441690", true, null, 0, "SA1722" },
                    { 2, 0, new DateTime(2026, 5, 31, 23, 44, 39, 274, DateTimeKind.Unspecified).AddTicks(4373), 1, null, 0, "admin@rajmango.com", true, "Admin", null, true, false, false, "User", "AQAAAAIAAYagAAAAENj6Z24Wh5FA2vqODDkAFqMA0dyhfdRU21lxWFjep3cadE3ATRqf2giXtHYCPdRTeQ==", "+8801323993377", true, null, 0, "AU1982" },
                    { 3, 0, new DateTime(2026, 5, 31, 23, 44, 39, 559, DateTimeKind.Unspecified).AddTicks(8946), 1, null, 0, "sr@rajmango.com", true, "Self", null, true, false, false, "Register", "AQAAAAIAAYagAAAAEDzIcI28+TX3WRMRT8vyZm0SwGgusk+2fIee5zfssfaXtAAizDuWUoBnkzZTki5EEg==", "+8801323993388", true, null, 0, "SR3300" }
                });

            migrationBuilder.InsertData(
                table: "CourierProviders",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Email", "IsActive", "IsDeleted", "Name", "Sequence", "SupportPhone", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7214), 1, null, 0, null, null, true, false, "Ahmed Parcel Service", 1, "01710000001", null, 0 },
                    { 2, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7225), 1, null, 0, null, null, true, false, "Janani Courier Service", 2, "01710000002", null, 0 },
                    { 3, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7235), 1, null, 0, null, null, true, false, "Karatoa Courier Service", 3, "01710000003", null, 0 },
                    { 4, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7245), 1, null, 0, null, null, true, false, "SR Parcel Services Ltd.", 4, "01710000004", null, 0 },
                    { 5, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7254), 1, null, 0, null, null, true, false, "Shodagor Express Limited", 5, "01710000005", null, 0 },
                    { 6, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7263), 1, null, 0, null, null, true, false, "SB Courier Service", 6, "01710000006", null, 0 },
                    { 7, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7273), 1, null, 0, null, null, true, false, "SA Paribahan", 7, "01710000007", null, 0 },
                    { 8, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7283), 1, null, 0, null, null, true, false, "Sundarban Courier", 8, "01710000008", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "MangoTypes",
                columns: new[] { "Id", "AverageWeight", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "ImagePath", "IsDeleted", "MangoGrade", "Name", "Region", "Sequence", "SweetnessLevel", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "325-350g", new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Local).AddTicks(6875), 1, null, 0, "A sweet and early-season mango, Gopalbhog is known for its rich aroma, fiberless flesh, and vibrant yellow skin. Popular in Rajshahi and Chapainawabganj.", "/uploads/mango-types/2026/05/mango-type-1-gopalbhog.jpg", false, 1, "Gopalbhog", "Rajshahi", 1, 4, null, 0 },
                    { 2, "400-425g", new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Local).AddTicks(6885), 1, null, 0, "Also known as Khirshapat, this premium mango is highly sought after for its buttery smooth texture and excellent sweetness. It’s the pride of Chapainawabganj.", "/uploads/mango-types/2026/05/mango-type-2-himsagor.jpg", false, 1, "Himsagor", "Chapainawabganj", 2, 4, null, 0 },
                    { 3, "375-400g", new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Local).AddTicks(6893), 1, null, 0, "Langra is a traditional mid-season mango with a distinct tangy-sweet taste. Its green skin remains even when ripe. Highly popular across Bangladesh.", "/uploads/mango-types/2026/05/mango-type-3-langra.jpg", false, 2, "Langra", "Rajshahi", 3, 3, null, 0 },
                    { 4, "250-300g", new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Local).AddTicks(6901), 1, null, 0, "A hybrid mango known for its long shelf life and rich aroma. Amrupali is intensely sweet and has a reddish hue when ripe. Great for gifting and exports.", "/uploads/mango-types/2026/05/mango-type-4-amrupali.jpg", false, 1, "Amrupali", "Rajshahi", 4, 3, null, 0 },
                    { 5, "250-275g", new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Local).AddTicks(6908), 1, null, 0, "A local variety with good sweetness and juiciness, Brindabon mangoes are medium-sized and ideal for table consumption. Rarely found outside local markets.", "/uploads/mango-types/2026/05/mango-type-5-brindabon.jpg", false, 2, "Brindabon", "Brindabonpur", 5, 2, null, 0 },
                    { 6, "850-950g", new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Local).AddTicks(6916), 1, null, 0, "Fazli mangoes are large, fleshy, and less fibrous, making them perfect for pulp and chutney. They are harvested late in the season and have excellent storage qualities.", "/uploads/mango-types/2026/05/mango-type-6-fazli.jpg", false, 2, "Fazli", "Rajshahi", 6, 2, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "IsDeleted", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "user.view", true, false, "user", "user.view", null, 0 },
                    { 2, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "user.create", true, false, "user", "user.create", null, 0 },
                    { 3, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "user.update", true, false, "user", "user.update", null, 0 },
                    { 4, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "user.delete", true, false, "user", "user.delete", null, 0 },
                    { 5, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "role.view", true, false, "role", "role.view", null, 0 },
                    { 6, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "role.create", true, false, "role", "role.create", null, 0 },
                    { 7, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "role.update", true, false, "role", "role.update", null, 0 },
                    { 8, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "role.delete", true, false, "role", "role.delete", null, 0 },
                    { 9, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "order.view", true, false, "order", "order.view", null, 0 },
                    { 10, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "order.create", true, false, "order", "order.create", null, 0 },
                    { 11, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "order.update", true, false, "order", "order.update", null, 0 },
                    { 12, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "order.delete", true, false, "order", "order.delete", null, 0 },
                    { 13, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "order.admin.view", true, false, "order.admin", "order.admin.view", null, 0 },
                    { 14, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "order.admin.manage", true, false, "order.admin", "order.admin.manage", null, 0 },
                    { 15, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "payment.view", true, false, "payment", "payment.view", null, 0 },
                    { 16, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "payment.create", true, false, "payment", "payment.create", null, 0 },
                    { 17, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "payment.update", true, false, "payment", "payment.update", null, 0 },
                    { 18, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "payment.delete", true, false, "payment", "payment.delete", null, 0 },
                    { 19, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "expense.view", true, false, "expense", "expense.view", null, 0 },
                    { 20, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "expense.create", true, false, "expense", "expense.create", null, 0 },
                    { 21, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "expense.update", true, false, "expense", "expense.update", null, 0 },
                    { 22, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "expense.delete", true, false, "expense", "expense.delete", null, 0 },
                    { 23, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "expense.type.view", true, false, "expense.type", "expense.type.view", null, 0 },
                    { 24, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "expense.type.create", true, false, "expense.type", "expense.type.create", null, 0 },
                    { 25, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "expense.type.update", true, false, "expense.type", "expense.type.update", null, 0 },
                    { 26, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "expense.type.delete", true, false, "expense.type", "expense.type.delete", null, 0 },
                    { 27, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.view", true, false, "courier", "courier.view", null, 0 },
                    { 28, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.create", true, false, "courier", "courier.create", null, 0 },
                    { 29, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.update", true, false, "courier", "courier.update", null, 0 },
                    { 30, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.delete", true, false, "courier", "courier.delete", null, 0 },
                    { 31, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "customer.view", true, false, "customer", "customer.view", null, 0 },
                    { 32, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "customer.create", true, false, "customer", "customer.create", null, 0 },
                    { 33, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "customer.update", true, false, "customer", "customer.update", null, 0 },
                    { 34, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "customer.delete", true, false, "customer", "customer.delete", null, 0 },
                    { 35, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "mango.type.view", true, false, "mango.type", "mango.type.view", null, 0 },
                    { 36, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "mango.type.manage", true, false, "mango.type", "mango.type.manage", null, 0 },
                    { 37, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "mango.availability.view", true, false, "mango.availability", "mango.availability.view", null, 0 },
                    { 38, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "mango.availability.manage", true, false, "mango.availability", "mango.availability.manage", null, 0 },
                    { 39, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "report.view", true, false, "report", "report.view", null, 0 },
                    { 40, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "dashboard.admin.view", true, false, "dashboard.admin", "dashboard.admin.view", null, 0 },
                    { 41, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "dashboard.customer.view", true, false, "dashboard.customer", "dashboard.customer.view", null, 0 },
                    { 42, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "complaint.submit", true, false, "complaint", "complaint.submit", null, 0 },
                    { 43, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "complaint.admin.view", true, false, "complaint.admin", "complaint.admin.view", null, 0 },
                    { 44, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "complaint.admin.manage", true, false, "complaint.admin", "complaint.admin.manage", null, 0 },
                    { 45, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "faq.manage", true, false, "faq", "faq.manage", null, 0 },
                    { 46, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "policy.view", true, false, "policy", "policy.view", null, 0 },
                    { 47, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "policy.manage", true, false, "policy", "policy.manage", null, 0 },
                    { 48, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "feedback.admin.view", true, false, "feedback.admin", "feedback.admin.view", null, 0 },
                    { 49, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "user.permission.view", true, false, "user.permission", "user.permission.view", null, 0 },
                    { 50, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "user.permission.grant", true, false, "user.permission", "user.permission.grant", null, 0 },
                    { 51, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "user.permission.revoke", true, false, "user.permission", "user.permission.revoke", null, 0 },
                    { 52, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.provider.view", true, false, "courier.provider", "courier.provider.view", null, 0 },
                    { 53, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.provider.create", true, false, "courier.provider", "courier.provider.create", null, 0 },
                    { 54, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.provider.update", true, false, "courier.provider", "courier.provider.update", null, 0 },
                    { 55, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.provider.delete", true, false, "courier.provider", "courier.provider.delete", null, 0 },
                    { 56, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.station.view", true, false, "courier.station", "courier.station.view", null, 0 },
                    { 57, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.station.create", true, false, "courier.station", "courier.station.create", null, 0 },
                    { 58, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.station.update", true, false, "courier.station", "courier.station.update", null, 0 },
                    { 59, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.station.delete", true, false, "courier.station", "courier.station.delete", null, 0 },
                    { 60, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.area.map.view", true, false, "courier.area.map", "courier.area.map.view", null, 0 },
                    { 61, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.area.map.create", true, false, "courier.area.map", "courier.area.map.create", null, 0 },
                    { 62, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.area.map.update", true, false, "courier.area.map", "courier.area.map.update", null, 0 },
                    { 63, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.area.map.delete", true, false, "courier.area.map", "courier.area.map.delete", null, 0 },
                    { 64, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.rate.config.view", true, false, "courier.rate.config", "courier.rate.config.view", null, 0 },
                    { 65, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.rate.config.create", true, false, "courier.rate.config", "courier.rate.config.create", null, 0 },
                    { 66, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.rate.config.update", true, false, "courier.rate.config", "courier.rate.config.update", null, 0 },
                    { 67, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(158), 1, null, 0, "courier.rate.config.delete", true, false, "courier.rate.config", "courier.rate.config.delete", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "IsDeleted", "IsSystemRole", "Name", "PermissionJson", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "system_admin", new DateTime(2026, 5, 31, 23, 44, 38, 707, DateTimeKind.Unspecified).AddTicks(5733), 1, null, 0, "Full system access including user and role management.", true, false, true, "System Admin", "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"order.admin.view\",\"order.admin.manage\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier.provider.view\",\"courier.provider.create\",\"courier.provider.update\",\"courier.provider.delete\",\"courier.station.view\",\"courier.station.create\",\"courier.station.update\",\"courier.station.delete\",\"courier.area.map.view\",\"courier.area.map.create\",\"courier.area.map.update\",\"courier.area.map.delete\",\"courier.rate.config.view\",\"courier.rate.config.create\",\"courier.rate.config.update\",\"courier.rate.config.delete\"]", null, 0 },
                    { 2, "admin", new DateTime(2026, 5, 31, 23, 44, 38, 707, DateTimeKind.Unspecified).AddTicks(6374), 1, null, 0, "Standard administrative access excluding system-level configurations.", true, false, true, "Admin", "[\"user.view\",\"user.create\",\"user.update\",\"user.delete\",\"role.view\",\"role.create\",\"role.update\",\"role.delete\",\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"order.admin.view\",\"order.admin.manage\",\"payment.view\",\"payment.create\",\"payment.update\",\"payment.delete\",\"expense.view\",\"expense.create\",\"expense.update\",\"expense.delete\",\"expense.type.view\",\"expense.type.create\",\"expense.type.update\",\"expense.type.delete\",\"courier.view\",\"courier.create\",\"courier.update\",\"courier.delete\",\"customer.view\",\"customer.create\",\"customer.update\",\"customer.delete\",\"mango.type.view\",\"mango.type.manage\",\"mango.availability.view\",\"mango.availability.manage\",\"report.view\",\"dashboard.admin.view\",\"dashboard.customer.view\",\"complaint.submit\",\"complaint.admin.view\",\"complaint.admin.manage\",\"faq.manage\",\"policy.view\",\"policy.manage\",\"feedback.admin.view\",\"user.permission.view\",\"user.permission.grant\",\"user.permission.revoke\",\"courier.provider.view\",\"courier.provider.create\",\"courier.provider.update\",\"courier.provider.delete\",\"courier.station.view\",\"courier.station.create\",\"courier.station.update\",\"courier.station.delete\",\"courier.area.map.view\",\"courier.area.map.create\",\"courier.area.map.update\",\"courier.area.map.delete\",\"courier.rate.config.view\",\"courier.rate.config.create\",\"courier.rate.config.update\",\"courier.rate.config.delete\"]", null, 0 },
                    { 3, "self_register", new DateTime(2026, 5, 31, 23, 44, 38, 707, DateTimeKind.Unspecified).AddTicks(6502), 1, null, 0, "Standard user like a customer access only order related features", true, false, true, "Self Register", "[\"order.view\",\"order.create\",\"order.update\",\"order.delete\",\"mango.type.view\",\"mango.availability.view\",\"dashboard.customer.view\",\"complaint.submit\",\"policy.view\"]", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "CourierRateConfigurations",
                columns: new[] { "Id", "CourierLocationType", "CourierProviderId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActive", "IsDeleted", "MinimumCharge", "RatePerKg", "Sequence", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 2, 1, 2, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 3, 1, 3, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 4, 1, 4, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 5, 1, 5, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 6, 1, 6, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 7, 1, 7, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 8, 1, 8, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 100.00m, 15.00m, 1, null, 0 },
                    { 9, 2, 1, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 10, 2, 2, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 11, 2, 3, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 12, 2, 4, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 13, 2, 5, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 14, 2, 6, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 15, 2, 7, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 },
                    { 16, 2, 8, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(8092), 1, null, 0, true, false, 150.00m, 25.00m, 2, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "CourierStations",
                columns: new[] { "Id", "AddressLine", "Area", "City", "CourierProviderId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "GoogleMapUrl", "IsActive", "IsDeleted", "Latitude", "Longitude", "Name", "SupportPhone1", "SupportPhone2", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Satmasjid Road", "Dhanmondi", "Dhaka", 1, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7393), 1, null, 0, null, null, true, false, null, null, "Ahmed - Dhanmondi Branch", "01720000001", null, null, 0 },
                    { 2, "Pallabi, Mirpur 10", "Mirpur", "Dhaka", 2, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7405), 1, null, 0, null, null, true, false, null, null, "Janani - Mirpur 10", "01720000002", null, null, 0 },
                    { 3, "Banani Block C", "Banani", "Dhaka", 3, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7415), 1, null, 0, null, null, true, false, null, null, "Karatoa - Banani", "01720000003", null, null, 0 },
                    { 4, "Gulshan Circle 2", "Gulshan 2", "Dhaka", 4, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7425), 1, null, 0, null, null, true, false, null, null, "SR - Gulshan 2", "01720000004", null, null, 0 },
                    { 5, "Near T&T Market", "Kawran Bazar", "Dhaka", 5, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7435), 1, null, 0, null, null, true, false, null, null, "Shodagor - Kawran Bazar", "01720000005", null, null, 0 },
                    { 6, "Opposite Bus Terminal", "Mohakhali", "Dhaka", 6, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7443), 1, null, 0, null, null, true, false, null, null, "SB - Mohakhali", "01720000006", null, null, 0 },
                    { 7, "Gulistan Underpass", "Gulistan", "Dhaka", 7, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7454), 1, null, 0, null, null, true, false, null, null, "SA - Gulistan", "01720000007", null, null, 0 },
                    { 8, "Gate 1", "New Market", "Dhaka", 8, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7464), 1, null, 0, null, null, true, false, null, null, "Sundarban - New Market", "01720000008", null, null, 0 },
                    { 9, "Malibagh Crossing", "Malibagh", "Dhaka", 7, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7472), 1, null, 0, null, null, true, false, null, null, "SA - Malibagh", "01720000009", null, null, 0 },
                    { 10, "Sector 7", "Uttara", "Dhaka", 8, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7480), 1, null, 0, null, null, true, false, null, null, "Sundarban - Uttara", "01720000010", null, null, 0 },
                    { 11, "Chowrasta", "Gazipur", "Gazipur", 6, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7489), 1, null, 0, null, null, true, false, null, null, "SB - Gazipur", "01720000011", null, null, 0 },
                    { 12, "Gulshan 1 Circle", "Gulshan 1", "Dhaka", 5, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7502), 1, null, 0, null, null, true, false, null, null, "Shodagor - Gulshan 1", "01720000012", null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 23, 1 },
                    { 24, 1 },
                    { 25, 1 },
                    { 26, 1 },
                    { 27, 1 },
                    { 28, 1 },
                    { 29, 1 },
                    { 30, 1 },
                    { 31, 1 },
                    { 32, 1 },
                    { 33, 1 },
                    { 34, 1 },
                    { 35, 1 },
                    { 36, 1 },
                    { 37, 1 },
                    { 38, 1 },
                    { 39, 1 },
                    { 40, 1 },
                    { 41, 1 },
                    { 42, 1 },
                    { 43, 1 },
                    { 44, 1 },
                    { 45, 1 },
                    { 46, 1 },
                    { 47, 1 },
                    { 48, 1 },
                    { 49, 1 },
                    { 50, 1 },
                    { 51, 1 },
                    { 52, 1 },
                    { 53, 1 },
                    { 54, 1 },
                    { 55, 1 },
                    { 56, 1 },
                    { 57, 1 },
                    { 58, 1 },
                    { 59, 1 },
                    { 60, 1 },
                    { 61, 1 },
                    { 62, 1 },
                    { 63, 1 },
                    { 64, 1 },
                    { 65, 1 },
                    { 66, 1 },
                    { 67, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 2 },
                    { 12, 2 },
                    { 13, 2 },
                    { 14, 2 },
                    { 15, 2 },
                    { 16, 2 },
                    { 17, 2 },
                    { 18, 2 },
                    { 19, 2 },
                    { 20, 2 },
                    { 21, 2 },
                    { 22, 2 },
                    { 23, 2 },
                    { 24, 2 },
                    { 25, 2 },
                    { 26, 2 },
                    { 27, 2 },
                    { 28, 2 },
                    { 29, 2 },
                    { 30, 2 },
                    { 31, 2 },
                    { 32, 2 },
                    { 33, 2 },
                    { 34, 2 },
                    { 35, 2 },
                    { 36, 2 },
                    { 37, 2 },
                    { 38, 2 },
                    { 39, 2 },
                    { 40, 2 },
                    { 41, 2 },
                    { 42, 2 },
                    { 43, 2 },
                    { 44, 2 },
                    { 45, 2 },
                    { 46, 2 },
                    { 47, 2 },
                    { 48, 2 },
                    { 49, 2 },
                    { 50, 2 },
                    { 51, 2 },
                    { 52, 2 },
                    { 53, 2 },
                    { 54, 2 },
                    { 55, 2 },
                    { 56, 2 },
                    { 57, 2 },
                    { 58, 2 },
                    { 59, 2 },
                    { 60, 2 },
                    { 61, 2 },
                    { 62, 2 },
                    { 63, 2 },
                    { 64, 2 },
                    { 65, 2 },
                    { 66, 2 },
                    { 67, 2 },
                    { 9, 3 },
                    { 10, 3 },
                    { 11, 3 },
                    { 12, 3 },
                    { 35, 3 },
                    { 37, 3 },
                    { 41, 3 },
                    { 42, 3 },
                    { 46, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "AssignedAt", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "RoleId", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(60), new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(56), 1, null, 0, false, 1, null, 0, 1 },
                    { 2, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(81), new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(79), 1, null, 0, false, 2, null, 0, 2 },
                    { 3, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(91), new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(88), 1, null, 0, false, 3, null, 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "CourierAreaMaps",
                columns: new[] { "Id", "Area", "CourierStationId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Dhanmondi", 1, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7844), 1, null, 0, false, null, 0 },
                    { 2, "Mirpur", 2, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7853), 1, null, 0, false, null, 0 },
                    { 3, "Banani", 3, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7860), 1, null, 0, false, null, 0 },
                    { 4, "Gulshan 2", 4, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7868), 1, null, 0, false, null, 0 },
                    { 5, "Kawran Bazar", 5, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7876), 1, null, 0, false, null, 0 },
                    { 6, "Mohakhali", 6, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7883), 1, null, 0, false, null, 0 },
                    { 7, "Gulistan", 7, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7891), 1, null, 0, false, null, 0 },
                    { 8, "New Market", 8, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7899), 1, null, 0, false, null, 0 },
                    { 9, "Malibagh", 9, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7908), 1, null, 0, false, null, 0 },
                    { 10, "Uttara", 10, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7916), 1, null, 0, false, null, 0 },
                    { 11, "Gazipur", 11, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7924), 1, null, 0, false, null, 0 },
                    { 12, "Gulshan 1", 12, new DateTime(2026, 5, 31, 23, 44, 39, 560, DateTimeKind.Unspecified).AddTicks(7931), 1, null, 0, false, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Email",
                table: "AppUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_PhoneNumber",
                table: "AppUsers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UserName",
                table: "AppUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintImages_ComplaintId",
                table: "ComplaintImages",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_OrderId",
                table: "Complaints",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_UserId",
                table: "Complaints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierAreaMaps_CourierStationId",
                table: "CourierAreaMaps",
                column: "CourierStationId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierProviders_Name",
                table: "CourierProviders",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_CourierRateConfigurations_Provider_LocationType_Active",
                table: "CourierRateConfigurations",
                columns: new[] { "CourierProviderId", "CourierLocationType" },
                unique: true,
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_CourierStations_CourierProviderId",
                table: "CourierStations",
                column: "CourierProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseAttachments_ExpenseId",
                table: "ExpenseAttachments",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Name",
                table: "Expenses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackImages_FeedbackId",
                table: "FeedbackImages",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_OrderId",
                table: "Feedbacks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JwtAuth_RevokedBy",
                table: "JwtAuth",
                column: "RevokedBy");

            migrationBuilder.CreateIndex(
                name: "IX_JwtAuth_UserId",
                table: "JwtAuth",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MangoAvailabilities_MangoTypeId",
                table: "MangoAvailabilities",
                column: "MangoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MangoTypes_Name",
                table: "MangoTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MangoTypeId",
                table: "OrderDetails",
                column: "MangoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CourierProviderId",
                table: "Orders",
                column: "CourierProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CourierStationId",
                table: "Orders",
                column: "CourierStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAttachments_PaymentId",
                table: "PaymentAttachments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Name",
                table: "Permissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_PaymentId",
                table: "Refunds",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_PermissionId",
                table: "UserPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId_RoleId",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "ComplaintImages");

            migrationBuilder.DropTable(
                name: "CourierAreaMaps");

            migrationBuilder.DropTable(
                name: "CourierRateConfigurations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ExpenseAttachments");

            migrationBuilder.DropTable(
                name: "FaqItems");

            migrationBuilder.DropTable(
                name: "FeedbackImages");

            migrationBuilder.DropTable(
                name: "JwtAuth");

            migrationBuilder.DropTable(
                name: "MangoAvailabilities");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderNumberCounters");

            migrationBuilder.DropTable(
                name: "PaymentAttachments");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Refunds");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "MangoTypes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "CourierStations");

            migrationBuilder.DropTable(
                name: "CourierProviders");
        }
    }
}
