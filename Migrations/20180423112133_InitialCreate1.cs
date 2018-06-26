using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace jannieCouture.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeRange",
                columns: table => new
                {
                    AgeRangeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeRange", x => x.AgeRangeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartStatus",
                columns: table => new
                {
                    CartStatusID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartStatus", x => x.CartStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFeedbackResponse",
                columns: table => new
                {
                    CustomerFeedbackResponseId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ParentResponseCustomerFeedbackResponseId = table.Column<int>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeedbackResponse", x => x.CustomerFeedbackResponseId);
                    table.ForeignKey(
                        name: "FK_CustomerFeedbackResponse_CustomerFeedbackResponse_ParentResponseCustomerFeedbackResponseId",
                        column: x => x.ParentResponseCustomerFeedbackResponseId,
                        principalTable: "CustomerFeedbackResponse",
                        principalColumn: "CustomerFeedbackResponseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryClass",
                columns: table => new
                {
                    DeliveryClassID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryClass", x => x.DeliveryClassID);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMethod",
                columns: table => new
                {
                    DeliveryMethodId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Cost = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TimeToDeliver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethod", x => x.DeliveryMethodId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryStatus",
                columns: table => new
                {
                    DeliveryStatusId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryStatus", x => x.DeliveryStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Demography",
                columns: table => new
                {
                    DemographyID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demography", x => x.DemographyID);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackStatus",
                columns: table => new
                {
                    FeedbackStatusID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackStatus", x => x.FeedbackStatusID);
                });

            migrationBuilder.CreateTable(
                name: "MaterialCategory",
                columns: table => new
                {
                    MaterialCategoryID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialCategory", x => x.MaterialCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementCategory",
                columns: table => new
                {
                    MeasurementCategoryID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementCategory", x => x.MeasurementCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementEntry",
                columns: table => new
                {
                    MeasurementEntryID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    MeasurementUnit = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementEntry", x => x.MeasurementEntryID);
                });

            migrationBuilder.CreateTable(
                name: "OrderPayment",
                columns: table => new
                {
                    OrderPaymentId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Balance = table.Column<double>(nullable: false),
                    TotalPaid = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPayment", x => x.OrderPaymentId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    OrderStatusID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.OrderStatusID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductCategoryID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ImageUrl = table.Column<string>(nullable: true),
                    MarketNames = table.Column<string[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Tags = table.Column<string[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ProductTag",
                columns: table => new
                {
                    ProductTagID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => x.ProductTagID);
                });

            migrationBuilder.CreateTable(
                name: "RatedEntity",
                columns: table => new
                {
                    RatedEntityID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatedEntity", x => x.RatedEntityID);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ExpiresOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Numberitems = table.Column<int>(nullable: false),
                    TotalCost = table.Column<double>(nullable: false),
                    USerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ShoppingCartId);
                });

            migrationBuilder.CreateTable(
                name: "SKU",
                columns: table => new
                {
                    SKUID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKU", x => x.SKUID);
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequestStatus",
                columns: table => new
                {
                    SupplyRequestStatusId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyRequestStatus", x => x.SupplyRequestStatusId);
                });

            migrationBuilder.CreateTable(
                name: "UserCategory",
                columns: table => new
                {
                    UserCategoryID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategory", x => x.UserCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "UserLiveStream",
                columns: table => new
                {
                    UserLiveStreamId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLiveStream", x => x.UserLiveStreamId);
                });

            migrationBuilder.CreateTable(
                name: "UserMeta",
                columns: table => new
                {
                    UserMetaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Gender = table.Column<string>(nullable: true),
                    ProfileImage = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeta", x => x.UserMetaId);
                });

            migrationBuilder.CreateTable(
                name: "UserSocialLink",
                columns: table => new
                {
                    UserSocialLinkId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SocialMediaBrand = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocialLink", x => x.UserSocialLinkId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CountryId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementCategoryEntry",
                columns: table => new
                {
                    MeasurementCategoryEntryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MeasurementCategoryID = table.Column<int>(nullable: true),
                    MeasurementEntryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementCategoryEntry", x => x.MeasurementCategoryEntryId);
                    table.ForeignKey(
                        name: "FK_MeasurementCategoryEntry_MeasurementCategory_MeasurementCategoryID",
                        column: x => x.MeasurementCategoryID,
                        principalTable: "MeasurementCategory",
                        principalColumn: "MeasurementCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeasurementCategoryEntry_MeasurementEntry_MeasurementEntryID",
                        column: x => x.MeasurementEntryID,
                        principalTable: "MeasurementEntry",
                        principalColumn: "MeasurementEntryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMeasurement",
                columns: table => new
                {
                    UserMeasurementId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MeasurementEntryID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeasurement", x => x.UserMeasurementId);
                    table.ForeignKey(
                        name: "FK_UserMeasurement_MeasurementEntry_MeasurementEntryID",
                        column: x => x.MeasurementEntryID,
                        principalTable: "MeasurementEntry",
                        principalColumn: "MeasurementEntryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ImageUrl = table.Column<string>(nullable: true),
                    MarketNames = table.Column<string[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PriceCurrent = table.Column<string>(nullable: true),
                    PriceRange = table.Column<string>(nullable: true),
                    ProductCategoryID = table.Column<int>(nullable: true),
                    Tags = table.Column<string[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFullfilment",
                columns: table => new
                {
                    CustomerFullfilmentId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    RatedEntityID = table.Column<int>(nullable: true),
                    RatingID = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFullfilment", x => x.CustomerFullfilmentId);
                    table.ForeignKey(
                        name: "FK_CustomerFullfilment_RatedEntity_RatedEntityID",
                        column: x => x.RatedEntityID,
                        principalTable: "RatedEntity",
                        principalColumn: "RatedEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerFullfilment_Rating_RatingID",
                        column: x => x.RatingID,
                        principalTable: "Rating",
                        principalColumn: "RatingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    OrderPaymentID = table.Column<int>(nullable: true),
                    OrderSerial = table.Column<string>(nullable: true),
                    ShoppingCartId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_OrderPayment_OrderPaymentID",
                        column: x => x.OrderPaymentID,
                        principalTable: "OrderPayment",
                        principalColumn: "OrderPaymentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MaterialCategoryID = table.Column<int>(nullable: true),
                    QuantityinStock = table.Column<double>(nullable: false),
                    SKUID = table.Column<int>(nullable: true),
                    WarningQuantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Material_MaterialCategory_MaterialCategoryID",
                        column: x => x.MaterialCategoryID,
                        principalTable: "MaterialCategory",
                        principalColumn: "MaterialCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Material_SKU_SKUID",
                        column: x => x.SKUID,
                        principalTable: "SKU",
                        principalColumn: "SKUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    UserCategoryID = table.Column<int>(nullable: true),
                    UserMetaId = table.Column<int>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserCategory_UserCategoryID",
                        column: x => x.UserCategoryID,
                        principalTable: "UserCategory",
                        principalColumn: "UserCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserMeta_UserMetaId",
                        column: x => x.UserMetaId,
                        principalTable: "UserMeta",
                        principalColumn: "UserMetaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAddress",
                columns: table => new
                {
                    DeliveryAddressId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    DeliveryStatusId = table.Column<int>(nullable: true),
                    LineAddress = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddress", x => x.DeliveryAddressId);
                    table.ForeignKey(
                        name: "FK_DeliveryAddress_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryAddress_DeliveryStatus_DeliveryStatusId",
                        column: x => x.DeliveryStatusId,
                        principalTable: "DeliveryStatus",
                        principalColumn: "DeliveryStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryAddress_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMeasurementHistory",
                columns: table => new
                {
                    UserMeasurementHistoryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    MeasurementEntryID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    UserMeasurementId = table.Column<int>(nullable: true),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeasurementHistory", x => x.UserMeasurementHistoryId);
                    table.ForeignKey(
                        name: "FK_UserMeasurementHistory_MeasurementEntry_MeasurementEntryID",
                        column: x => x.MeasurementEntryID,
                        principalTable: "MeasurementEntry",
                        principalColumn: "MeasurementEntryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMeasurementHistory_UserMeasurement_UserMeasurementId",
                        column: x => x.UserMeasurementId,
                        principalTable: "UserMeasurement",
                        principalColumn: "UserMeasurementId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDemography",
                columns: table => new
                {
                    ProductDemographyId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DemographyID = table.Column<int>(nullable: true),
                    ProductID = table.Column<int>(nullable: true),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDemography", x => x.ProductDemographyId);
                    table.ForeignKey(
                        name: "FK_ProductDemography_Demography_DemographyID",
                        column: x => x.DemographyID,
                        principalTable: "Demography",
                        principalColumn: "DemographyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDemography_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    ProductDetailID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Currency = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    MarketNames = table.Column<string[]>(nullable: true),
                    MeasurementCategorry = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.ProductDetailID);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFeedback",
                columns: table => new
                {
                    CustomerFeedbackId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Feedback = table.Column<string>(nullable: true),
                    FeedbackStatusID = table.Column<int>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    ParentFeedbackCustomerFeedbackId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeedback", x => x.CustomerFeedbackId);
                    table.ForeignKey(
                        name: "FK_CustomerFeedback_FeedbackStatus_FeedbackStatusID",
                        column: x => x.FeedbackStatusID,
                        principalTable: "FeedbackStatus",
                        principalColumn: "FeedbackStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerFeedback_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerFeedback_CustomerFeedback_ParentFeedbackCustomerFeedbackId",
                        column: x => x.ParentFeedbackCustomerFeedbackId,
                        principalTable: "CustomerFeedback",
                        principalColumn: "CustomerFeedbackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMaterial",
                columns: table => new
                {
                    CustomerMaterialId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateDelivered = table.Column<DateTime>(nullable: true),
                    DatePlaced = table.Column<DateTime>(nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(nullable: true),
                    MaterialId = table.Column<int>(nullable: true),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMaterial", x => x.CustomerMaterialId);
                    table.ForeignKey(
                        name: "FK_CustomerMaterial_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequest",
                columns: table => new
                {
                    SupplyRequestId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateFullfilled = table.Column<DateTime>(nullable: true),
                    MaterialId = table.Column<int>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    SupplyRequestStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyRequest", x => x.SupplyRequestId);
                    table.ForeignKey(
                        name: "FK_SupplyRequest_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplyRequest_SupplyRequestStatus_SupplyRequestStatusId",
                        column: x => x.SupplyRequestStatusId,
                        principalTable: "SupplyRequestStatus",
                        principalColumn: "SupplyRequestStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AddressDeliveryAddressId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    RatingID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                    table.ForeignKey(
                        name: "FK_Vendor_DeliveryAddress_AddressDeliveryAddressId",
                        column: x => x.AddressDeliveryAddressId,
                        principalTable: "DeliveryAddress",
                        principalColumn: "DeliveryAddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendor_Rating_RatingID",
                        column: x => x.RatingID,
                        principalTable: "Rating",
                        principalColumn: "RatingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDeliveryClass",
                columns: table => new
                {
                    ProductDeliveryClassId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DeliveryClassID = table.Column<int>(nullable: true),
                    PercentageAdded = table.Column<double>(nullable: false),
                    ProductDetailID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDeliveryClass", x => x.ProductDeliveryClassId);
                    table.ForeignKey(
                        name: "FK_ProductDeliveryClass_DeliveryClass_DeliveryClassID",
                        column: x => x.DeliveryClassID,
                        principalTable: "DeliveryClass",
                        principalColumn: "DeliveryClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDeliveryClass_ProductDetail_ProductDetailID",
                        column: x => x.ProductDetailID,
                        principalTable: "ProductDetail",
                        principalColumn: "ProductDetailID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetailPriceHistory",
                columns: table => new
                {
                    ProductDetailPriceHistoryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AgeRangeId = table.Column<int>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateExpire = table.Column<DateTime>(nullable: true),
                    Discount = table.Column<double>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ProductDetailID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetailPriceHistory", x => x.ProductDetailPriceHistoryId);
                    table.ForeignKey(
                        name: "FK_ProductDetailPriceHistory_AgeRange_AgeRangeId",
                        column: x => x.AgeRangeId,
                        principalTable: "AgeRange",
                        principalColumn: "AgeRangeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetailPriceHistory_ProductDetail_ProductDetailID",
                        column: x => x.ProductDetailID,
                        principalTable: "ProductDetail",
                        principalColumn: "ProductDetailID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CartStatusID = table.Column<int>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ProductDetailID = table.Column<int>(nullable: true),
                    Quantiy = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_CartStatus_CartStatusID",
                        column: x => x.CartStatusID,
                        principalTable: "CartStatus",
                        principalColumn: "CartStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ProductDetail_ProductDetailID",
                        column: x => x.ProductDetailID,
                        principalTable: "ProductDetail",
                        principalColumn: "ProductDetailID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    SupplyId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateFullfilled = table.Column<DateTime>(nullable: true),
                    DatePlaced = table.Column<DateTime>(nullable: true),
                    MaterailMaterialId = table.Column<int>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    SupplyRequestStatusId = table.Column<int>(nullable: true),
                    VendorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => x.SupplyId);
                    table.ForeignKey(
                        name: "FK_Supply_Material_MaterailMaterialId",
                        column: x => x.MaterailMaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supply_SupplyRequestStatus_SupplyRequestStatusId",
                        column: x => x.SupplyRequestStatusId,
                        principalTable: "SupplyRequestStatus",
                        principalColumn: "SupplyRequestStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supply_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendorFeedbackResponse",
                columns: table => new
                {
                    VendorFeedbackResponseId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ParentResponseVendorFeedbackResponseId = table.Column<int>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    VendorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorFeedbackResponse", x => x.VendorFeedbackResponseId);
                    table.ForeignKey(
                        name: "FK_VendorFeedbackResponse_VendorFeedbackResponse_ParentResponseVendorFeedbackResponseId",
                        column: x => x.ParentResponseVendorFeedbackResponseId,
                        principalTable: "VendorFeedbackResponse",
                        principalColumn: "VendorFeedbackResponseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendorFeedbackResponse_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetailPrice",
                columns: table => new
                {
                    ProductDetailPriceId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AgeRangeId = table.Column<int>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Discount = table.Column<double>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ProductDetailID = table.Column<int>(nullable: true),
                    ProductDetailPriceHistoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetailPrice", x => x.ProductDetailPriceId);
                    table.ForeignKey(
                        name: "FK_ProductDetailPrice_AgeRange_AgeRangeId",
                        column: x => x.AgeRangeId,
                        principalTable: "AgeRange",
                        principalColumn: "AgeRangeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetailPrice_ProductDetail_ProductDetailID",
                        column: x => x.ProductDetailID,
                        principalTable: "ProductDetail",
                        principalColumn: "ProductDetailID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetailPrice_ProductDetailPriceHistory_ProductDetailPriceHistoryId",
                        column: x => x.ProductDetailPriceHistoryId,
                        principalTable: "ProductDetailPriceHistory",
                        principalColumn: "ProductDetailPriceHistoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DeliveryClassID = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    OrderStatusID = table.Column<int>(nullable: true),
                    ShoppingCartItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_DeliveryClass_DeliveryClassID",
                        column: x => x.DeliveryClassID,
                        principalTable: "DeliveryClass",
                        principalColumn: "DeliveryClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_OrderStatus_OrderStatusID",
                        column: x => x.OrderStatusID,
                        principalTable: "OrderStatus",
                        principalColumn: "OrderStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_ShoppingCartItem_ShoppingCartItemId",
                        column: x => x.ShoppingCartItemId,
                        principalTable: "ShoppingCartItem",
                        principalColumn: "ShoppingCartItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplyPayment",
                columns: table => new
                {
                    SupplyPaymentId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Balance = table.Column<double>(nullable: false),
                    SupplyId = table.Column<int>(nullable: true),
                    TotalPaid = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyPayment", x => x.SupplyPaymentId);
                    table.ForeignKey(
                        name: "FK_SupplyPayment_Supply_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supply",
                        principalColumn: "SupplyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplyReceived",
                columns: table => new
                {
                    SupplyReceivedId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateReceived = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    SupplyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyReceived", x => x.SupplyReceivedId);
                    table.ForeignKey(
                        name: "FK_SupplyReceived_Supply_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supply",
                        principalColumn: "SupplyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendorFeedback",
                columns: table => new
                {
                    VendorFeedbackId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Feedback = table.Column<string>(nullable: true),
                    FeedbackStatusID = table.Column<int>(nullable: true),
                    ParentFeedbackVendorFeedbackId = table.Column<int>(nullable: true),
                    SupplyId = table.Column<int>(nullable: true),
                    VendorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorFeedback", x => x.VendorFeedbackId);
                    table.ForeignKey(
                        name: "FK_VendorFeedback_FeedbackStatus_FeedbackStatusID",
                        column: x => x.FeedbackStatusID,
                        principalTable: "FeedbackStatus",
                        principalColumn: "FeedbackStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendorFeedback_VendorFeedback_ParentFeedbackVendorFeedbackId",
                        column: x => x.ParentFeedbackVendorFeedbackId,
                        principalTable: "VendorFeedback",
                        principalColumn: "VendorFeedbackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendorFeedback_Supply_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supply",
                        principalColumn: "SupplyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendorFeedback_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemDeliveryAddress",
                columns: table => new
                {
                    OrderItemDeliveryAddressId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DeliveryAddressId = table.Column<int>(nullable: true),
                    DeliveryMethodId = table.Column<int>(nullable: true),
                    DeliveryStatusId = table.Column<int>(nullable: true),
                    OrderItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemDeliveryAddress", x => x.OrderItemDeliveryAddressId);
                    table.ForeignKey(
                        name: "FK_OrderItemDeliveryAddress_DeliveryAddress_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "DeliveryAddress",
                        principalColumn: "DeliveryAddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItemDeliveryAddress_DeliveryMethod_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethod",
                        principalColumn: "DeliveryMethodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItemDeliveryAddress_DeliveryStatus_DeliveryStatusId",
                        column: x => x.DeliveryStatusId,
                        principalTable: "DeliveryStatus",
                        principalColumn: "DeliveryStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItemDeliveryAddress_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemMeasurement",
                columns: table => new
                {
                    OrderItemMeasurementId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CanBeModified = table.Column<bool>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemMeasurement", x => x.OrderItemMeasurementId);
                    table.ForeignKey(
                        name: "FK_OrderItemMeasurement_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPaymentHistory",
                columns: table => new
                {
                    OrderPaymentHistoryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Amount = table.Column<double>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: true),
                    OrderPaymentId = table.Column<int>(nullable: true),
                    PaymentMethodId = table.Column<int>(nullable: true),
                    Userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPaymentHistory", x => x.OrderPaymentHistoryId);
                    table.ForeignKey(
                        name: "FK_OrderPaymentHistory_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPaymentHistory_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPaymentHistory_OrderPayment_OrderPaymentId",
                        column: x => x.OrderPaymentId,
                        principalTable: "OrderPayment",
                        principalColumn: "OrderPaymentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPaymentHistory_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplyPaymentHistory",
                columns: table => new
                {
                    SupplyPaymentHistoryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Amount = table.Column<double>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    PaymentMethodId = table.Column<int>(nullable: true),
                    SupplyPaymentId = table.Column<int>(nullable: true),
                    Userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyPaymentHistory", x => x.SupplyPaymentHistoryId);
                    table.ForeignKey(
                        name: "FK_SupplyPaymentHistory_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplyPaymentHistory_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplyPaymentHistory_SupplyPayment_SupplyPaymentId",
                        column: x => x.SupplyPaymentId,
                        principalTable: "SupplyPayment",
                        principalColumn: "SupplyPaymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemMeasurementDetail",
                columns: table => new
                {
                    OrderItemMeasurementDetailId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MeasurementEntryID = table.Column<int>(nullable: true),
                    OrderItemMeasurementId = table.Column<int>(nullable: true),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemMeasurementDetail", x => x.OrderItemMeasurementDetailId);
                    table.ForeignKey(
                        name: "FK_OrderItemMeasurementDetail_MeasurementEntry_MeasurementEntryID",
                        column: x => x.MeasurementEntryID,
                        principalTable: "MeasurementEntry",
                        principalColumn: "MeasurementEntryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItemMeasurementDetail_OrderItemMeasurement_OrderItemMeasurementId",
                        column: x => x.OrderItemMeasurementId,
                        principalTable: "OrderItemMeasurement",
                        principalColumn: "OrderItemMeasurementId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserCategoryID",
                table: "AspNetUsers",
                column: "UserCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserMetaId",
                table: "AspNetUsers",
                column: "UserMetaId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedback_FeedbackStatusID",
                table: "CustomerFeedback",
                column: "FeedbackStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedback_OrderId",
                table: "CustomerFeedback",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedback_ParentFeedbackCustomerFeedbackId",
                table: "CustomerFeedback",
                column: "ParentFeedbackCustomerFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbackResponse_ParentResponseCustomerFeedbackResponseId",
                table: "CustomerFeedbackResponse",
                column: "ParentResponseCustomerFeedbackResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFullfilment_RatedEntityID",
                table: "CustomerFullfilment",
                column: "RatedEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFullfilment_RatingID",
                table: "CustomerFullfilment",
                column: "RatingID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMaterial_MaterialId",
                table: "CustomerMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddress_CountryId",
                table: "DeliveryAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddress_DeliveryStatusId",
                table: "DeliveryAddress",
                column: "DeliveryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddress_StateId",
                table: "DeliveryAddress",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialCategoryID",
                table: "Material",
                column: "MaterialCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SKUID",
                table: "Material",
                column: "SKUID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementCategoryEntry_MeasurementCategoryID",
                table: "MeasurementCategoryEntry",
                column: "MeasurementCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementCategoryEntry_MeasurementEntryID",
                table: "MeasurementCategoryEntry",
                column: "MeasurementEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderPaymentID",
                table: "Order",
                column: "OrderPaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShoppingCartId",
                table: "Order",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_DeliveryClassID",
                table: "OrderItem",
                column: "DeliveryClassID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderStatusID",
                table: "OrderItem",
                column: "OrderStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ShoppingCartItemId",
                table: "OrderItem",
                column: "ShoppingCartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDeliveryAddress_DeliveryAddressId",
                table: "OrderItemDeliveryAddress",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDeliveryAddress_DeliveryMethodId",
                table: "OrderItemDeliveryAddress",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDeliveryAddress_DeliveryStatusId",
                table: "OrderItemDeliveryAddress",
                column: "DeliveryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDeliveryAddress_OrderItemId",
                table: "OrderItemDeliveryAddress",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemMeasurement_OrderItemId",
                table: "OrderItemMeasurement",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemMeasurementDetail_MeasurementEntryID",
                table: "OrderItemMeasurementDetail",
                column: "MeasurementEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemMeasurementDetail_OrderItemMeasurementId",
                table: "OrderItemMeasurementDetail",
                column: "OrderItemMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentHistory_CurrencyId",
                table: "OrderPaymentHistory",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentHistory_OrderItemId",
                table: "OrderPaymentHistory",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentHistory_OrderPaymentId",
                table: "OrderPaymentHistory",
                column: "OrderPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentHistory_PaymentMethodId",
                table: "OrderPaymentHistory",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryID",
                table: "Product",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDeliveryClass_DeliveryClassID",
                table: "ProductDeliveryClass",
                column: "DeliveryClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDeliveryClass_ProductDetailID",
                table: "ProductDeliveryClass",
                column: "ProductDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDemography_DemographyID",
                table: "ProductDemography",
                column: "DemographyID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDemography_ProductID",
                table: "ProductDemography",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductID",
                table: "ProductDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailPrice_AgeRangeId",
                table: "ProductDetailPrice",
                column: "AgeRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailPrice_ProductDetailID",
                table: "ProductDetailPrice",
                column: "ProductDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailPrice_ProductDetailPriceHistoryId",
                table: "ProductDetailPrice",
                column: "ProductDetailPriceHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailPriceHistory_AgeRangeId",
                table: "ProductDetailPriceHistory",
                column: "AgeRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailPriceHistory_ProductDetailID",
                table: "ProductDetailPriceHistory",
                column: "ProductDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_CartStatusID",
                table: "ShoppingCartItem",
                column: "CartStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_OrderId",
                table: "ShoppingCartItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ProductDetailID",
                table: "ShoppingCartItem",
                column: "ProductDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_MaterailMaterialId",
                table: "Supply",
                column: "MaterailMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_SupplyRequestStatusId",
                table: "Supply",
                column: "SupplyRequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_VendorId",
                table: "Supply",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyPayment_SupplyId",
                table: "SupplyPayment",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyPaymentHistory_CurrencyId",
                table: "SupplyPaymentHistory",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyPaymentHistory_PaymentMethodId",
                table: "SupplyPaymentHistory",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyPaymentHistory_SupplyPaymentId",
                table: "SupplyPaymentHistory",
                column: "SupplyPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyReceived_SupplyId",
                table: "SupplyReceived",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyRequest_MaterialId",
                table: "SupplyRequest",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyRequest_SupplyRequestStatusId",
                table: "SupplyRequest",
                column: "SupplyRequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeasurement_MeasurementEntryID",
                table: "UserMeasurement",
                column: "MeasurementEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeasurementHistory_MeasurementEntryID",
                table: "UserMeasurementHistory",
                column: "MeasurementEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeasurementHistory_UserMeasurementId",
                table: "UserMeasurementHistory",
                column: "UserMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_AddressDeliveryAddressId",
                table: "Vendor",
                column: "AddressDeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_RatingID",
                table: "Vendor",
                column: "RatingID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorFeedback_FeedbackStatusID",
                table: "VendorFeedback",
                column: "FeedbackStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorFeedback_ParentFeedbackVendorFeedbackId",
                table: "VendorFeedback",
                column: "ParentFeedbackVendorFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorFeedback_SupplyId",
                table: "VendorFeedback",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorFeedback_VendorId",
                table: "VendorFeedback",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorFeedbackResponse_ParentResponseVendorFeedbackResponseId",
                table: "VendorFeedbackResponse",
                column: "ParentResponseVendorFeedbackResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorFeedbackResponse_VendorId",
                table: "VendorFeedbackResponse",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerFeedback");

            migrationBuilder.DropTable(
                name: "CustomerFeedbackResponse");

            migrationBuilder.DropTable(
                name: "CustomerFullfilment");

            migrationBuilder.DropTable(
                name: "CustomerMaterial");

            migrationBuilder.DropTable(
                name: "MeasurementCategoryEntry");

            migrationBuilder.DropTable(
                name: "OrderItemDeliveryAddress");

            migrationBuilder.DropTable(
                name: "OrderItemMeasurementDetail");

            migrationBuilder.DropTable(
                name: "OrderPaymentHistory");

            migrationBuilder.DropTable(
                name: "ProductDeliveryClass");

            migrationBuilder.DropTable(
                name: "ProductDemography");

            migrationBuilder.DropTable(
                name: "ProductDetailPrice");

            migrationBuilder.DropTable(
                name: "ProductTag");

            migrationBuilder.DropTable(
                name: "SupplyPaymentHistory");

            migrationBuilder.DropTable(
                name: "SupplyReceived");

            migrationBuilder.DropTable(
                name: "SupplyRequest");

            migrationBuilder.DropTable(
                name: "UserLiveStream");

            migrationBuilder.DropTable(
                name: "UserMeasurementHistory");

            migrationBuilder.DropTable(
                name: "UserSocialLink");

            migrationBuilder.DropTable(
                name: "VendorFeedback");

            migrationBuilder.DropTable(
                name: "VendorFeedbackResponse");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RatedEntity");

            migrationBuilder.DropTable(
                name: "MeasurementCategory");

            migrationBuilder.DropTable(
                name: "DeliveryMethod");

            migrationBuilder.DropTable(
                name: "OrderItemMeasurement");

            migrationBuilder.DropTable(
                name: "Demography");

            migrationBuilder.DropTable(
                name: "ProductDetailPriceHistory");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "SupplyPayment");

            migrationBuilder.DropTable(
                name: "UserMeasurement");

            migrationBuilder.DropTable(
                name: "FeedbackStatus");

            migrationBuilder.DropTable(
                name: "UserCategory");

            migrationBuilder.DropTable(
                name: "UserMeta");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "AgeRange");

            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.DropTable(
                name: "MeasurementEntry");

            migrationBuilder.DropTable(
                name: "DeliveryClass");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "SupplyRequestStatus");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "CartStatus");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "MaterialCategory");

            migrationBuilder.DropTable(
                name: "SKU");

            migrationBuilder.DropTable(
                name: "DeliveryAddress");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "OrderPayment");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "DeliveryStatus");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
