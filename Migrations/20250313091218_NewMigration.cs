using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseManagementPortal.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Activation");

            migrationBuilder.EnsureSchema(
                name: "Reseller");

            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.CreateTable(
                name: "AddressType",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactType",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SelectOrder = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceType",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationRole",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationType",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageDetails",
                schema: "Activation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Legacy = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    LegacyPlus = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Current = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Advanced = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Engineering = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Hybrid = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Flags = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Subscription = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    RoleKeyId = table.Column<int>(type: "int", nullable: false, defaultValue: -1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SerialNumberRequestLog",
                schema: "Activation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RequestedSN = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumberRequestLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAccount",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationTypeId = table.Column<int>(type: "int", nullable: false),
                    ParentOrganizationId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationAccount_OrganizationAccount",
                        column: x => x.ParentOrganizationId,
                        principalSchema: "Reseller",
                        principalTable: "OrganizationAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationAccount_OrganizationType",
                        column: x => x.OrganizationTypeId,
                        principalSchema: "Reseller",
                        principalTable: "OrganizationType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SerialNumberDetails",
                schema: "Activation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumberRequestLogID = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AccountID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Prefix = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsTemp = table.Column<bool>(type: "bit", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    LatestModificationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ResellerCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: ""),
                    ResellerAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    ResellerInvoice = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    ResellerInvoiceLastRenew = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumberDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SerialNumberDetails_SerialNumberRequestLogID",
                        column: x => x.SerialNumberRequestLogID,
                        principalSchema: "Activation",
                        principalTable: "SerialNumberRequestLog",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationAccountId = table.Column<int>(type: "int", nullable: false),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceType",
                        column: x => x.InvoiceTypeId,
                        principalSchema: "Reseller",
                        principalTable: "InvoiceType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoice_OrganizationAccount",
                        column: x => x.OrganizationAccountId,
                        principalSchema: "Reseller",
                        principalTable: "OrganizationAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAddress",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationAccountId = table.Column<int>(type: "int", nullable: false),
                    AddressTypeId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    State = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationAccount_OrganizationAddress",
                        column: x => x.OrganizationAccountId,
                        principalSchema: "Reseller",
                        principalTable: "OrganizationAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationAddress_AddressType",
                        column: x => x.AddressTypeId,
                        principalSchema: "Reseller",
                        principalTable: "AddressType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationAddress_Country",
                        column: x => x.CountryId,
                        principalSchema: "Reseller",
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationContact",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationAccountId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    OrganizationRoleId = table.Column<int>(type: "int", nullable: false),
                    ContactTypeId = table.Column<int>(type: "int", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Login = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    LoginUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationContact_ContactType",
                        column: x => x.ContactTypeId,
                        principalSchema: "Reseller",
                        principalTable: "ContactType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationContact_LoginUser",
                        column: x => x.LoginUserId,
                        principalSchema: "identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationContact_OrganizationAccount",
                        column: x => x.OrganizationAccountId,
                        principalSchema: "Reseller",
                        principalTable: "OrganizationAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationContact_OrganizationRole",
                        column: x => x.OrganizationRoleId,
                        principalSchema: "Reseller",
                        principalTable: "OrganizationRole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationPackageDetails",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationAccountId = table.Column<int>(type: "int", nullable: false),
                    PackageDetailsId = table.Column<int>(type: "int", nullable: false),
                    SerialNumbersCount = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationPackageDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationPackageDetails_OrganizationAccount",
                        column: x => x.OrganizationAccountId,
                        principalSchema: "Reseller",
                        principalTable: "OrganizationAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationPackageDetails_PackageDetails",
                        column: x => x.PackageDetailsId,
                        principalSchema: "Activation",
                        principalTable: "PackageDetails",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ActivationDetails",
                schema: "Activation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumberDetailsID = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: ""),
                    Organization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: ""),
                    SystemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: ""),
                    ProfileHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateActivated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllowNewMachine = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivationDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActivationDetails_SerialNumberDetails",
                        column: x => x.SerialNumberDetailsID,
                        principalSchema: "Activation",
                        principalTable: "SerialNumberDetails",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ActivationStatusLogs",
                schema: "Activation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumberDetailID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivationStatusLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActivationStatusLogs_SerialNumberDetails",
                        column: x => x.SerialNumberDetailID,
                        principalSchema: "Activation",
                        principalTable: "SerialNumberDetails",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionItem",
                schema: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    SerialNumberDetailsId = table.Column<int>(type: "int", nullable: false),
                    EMailSentCount = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValueSql: "(suser_sname())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionItem_Invoice",
                        column: x => x.InvoiceId,
                        principalSchema: "Reseller",
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionItem_SerialNumberDetails",
                        column: x => x.SerialNumberDetailsId,
                        principalSchema: "Activation",
                        principalTable: "SerialNumberDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivationDetails_SerialNumberDetailsID",
                schema: "Activation",
                table: "ActivationDetails",
                column: "SerialNumberDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivationStatusLogs_SerialNumberDetailID",
                schema: "Activation",
                table: "ActivationStatusLogs",
                column: "SerialNumberDetailID");

            migrationBuilder.CreateIndex(
                name: "UQ_AddressType_Name",
                schema: "Reseller",
                table: "AddressType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "identity",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "identity",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "identity",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "identity",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "identity",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "identity",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "identity",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_ContactType_Name",
                schema: "Reseller",
                table: "ContactType",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_Country_Name",
                schema: "Reseller",
                table: "Country",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceType",
                schema: "Reseller",
                table: "Invoice",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_OrganizationAccount",
                schema: "Reseller",
                table: "Invoice",
                column: "OrganizationAccountId");

            migrationBuilder.CreateIndex(
                name: "UQ_InvoiceType_Name",
                schema: "Reseller",
                table: "InvoiceType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAccount_Account",
                schema: "Reseller",
                table: "OrganizationAccount",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAccount_OrganizationType",
                schema: "Reseller",
                table: "OrganizationAccount",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAccount_ParentOrganizationId",
                schema: "Reseller",
                table: "OrganizationAccount",
                column: "ParentOrganizationId");

            migrationBuilder.CreateIndex(
                name: "UQ_OrganizationAccount_Name",
                schema: "Reseller",
                table: "OrganizationAccount",
                columns: new[] { "Name", "ParentOrganizationId" },
                unique: true,
                filter: "[ParentOrganizationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAddress_AddressType",
                schema: "Reseller",
                table: "OrganizationAddress",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAddress_Country",
                schema: "Reseller",
                table: "OrganizationAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAddress_OrganizationAccount",
                schema: "Reseller",
                table: "OrganizationAddress",
                column: "OrganizationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAddress_OrganizationAccountId",
                schema: "Reseller",
                table: "OrganizationAddress",
                column: "OrganizationAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationContact_ContactType",
                schema: "Reseller",
                table: "OrganizationContact",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationContact_LoginUserId",
                schema: "Reseller",
                table: "OrganizationContact",
                column: "LoginUserId",
                unique: true,
                filter: "[LoginUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationContact_OrganizationAccount",
                schema: "Reseller",
                table: "OrganizationContact",
                column: "OrganizationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationContact_OrganizationRoleId",
                schema: "Reseller",
                table: "OrganizationContact",
                column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPackageDetails_OrganizationAccountId",
                schema: "Reseller",
                table: "OrganizationPackageDetails",
                column: "OrganizationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPackageDetails_PackageDetailsId",
                schema: "Reseller",
                table: "OrganizationPackageDetails",
                column: "PackageDetailsId");

            migrationBuilder.CreateIndex(
                name: "UQ_OrganizationRole_Name",
                schema: "Reseller",
                table: "OrganizationRole",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumberDetails_SerialNumberRequestLogID",
                schema: "Activation",
                table: "SerialNumberDetails",
                column: "SerialNumberRequestLogID");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionItem_InvoiceId",
                schema: "Reseller",
                table: "SubscriptionItem",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionItem_SerialNumberDetailsId",
                schema: "Reseller",
                table: "SubscriptionItem",
                column: "SerialNumberDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivationDetails",
                schema: "Activation");

            migrationBuilder.DropTable(
                name: "ActivationStatusLogs",
                schema: "Activation");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "OrganizationAddress",
                schema: "Reseller");

            migrationBuilder.DropTable(
                name: "OrganizationContact",
                schema: "Reseller");

            migrationBuilder.DropTable(
                name: "OrganizationPackageDetails",
                schema: "Reseller");

            migrationBuilder.DropTable(
                name: "SubscriptionItem",
                schema: "Reseller");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AddressType",
                schema: "Reseller");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Reseller");

            migrationBuilder.DropTable(
                name: "ContactType",
                schema: "Reseller");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "OrganizationRole",
                schema: "Reseller");

            migrationBuilder.DropTable(
                name: "PackageDetails",
                schema: "Activation");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "Reseller");

            migrationBuilder.DropTable(
                name: "SerialNumberDetails",
                schema: "Activation");

            migrationBuilder.DropTable(
                name: "InvoiceType",
                schema: "Reseller");

            migrationBuilder.DropTable(
                name: "OrganizationAccount",
                schema: "Reseller");

            migrationBuilder.DropTable(
                name: "SerialNumberRequestLog",
                schema: "Activation");

            migrationBuilder.DropTable(
                name: "OrganizationType",
                schema: "Reseller");
        }
    }
}
