using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeStoreApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikeTypes",
                columns: table => new
                {
                    BikeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeTypes", x => x.BikeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatuses",
                columns: table => new
                {
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentStatusCode = table.Column<bool>(type: "bit", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatuses", x => x.PaymentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "RentalRates",
                columns: table => new
                {
                    RentalRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyRate = table.Column<double>(type: "float", nullable: true),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalRates", x => x.RentalRateId);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialFeatures",
                columns: table => new
                {
                    SpecialFeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElectricMotor = table.Column<bool>(type: "bit", nullable: false),
                    Basket = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllTerrain = table.Column<bool>(type: "bit", nullable: false),
                    ChildSeat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialFeatures", x => x.SpecialFeatureId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    BikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.BikeId);
                    table.ForeignKey(
                        name: "FK_Bikes_RentalRates_RateId",
                        column: x => x.RateId,
                        principalTable: "RentalRates",
                        principalColumn: "RentalRateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bikes_SpecialFeatures_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "SpecialFeatures",
                        principalColumn: "SpecialFeatureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BikesInShops",
                columns: table => new
                {
                    BikesInShopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeId = table.Column<int>(type: "int", nullable: true),
                    DateTimeIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikesInShops", x => x.BikesInShopId);
                    table.ForeignKey(
                        name: "FK_BikesInShops_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BikesInShops_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeId = table.Column<int>(type: "int", nullable: false),
                    CustId = table.Column<int>(type: "int", nullable: false),
                    RateId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatusCode = table.Column<bool>(type: "bit", nullable: false),
                    BookedStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookedEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RentalPaymentDue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentalPaymentMade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatusCodeNavigationPaymentStatusId = table.Column<int>(type: "int", nullable: true),
                    Rented = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rentals_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Customers_CustId",
                        column: x => x.CustId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_PaymentStatuses_PaymentStatusCodeNavigationPaymentStatusId",
                        column: x => x.PaymentStatusCodeNavigationPaymentStatusId,
                        principalTable: "PaymentStatuses",
                        principalColumn: "PaymentStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartLine",
                columns: table => new
                {
                    CartLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RentalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLine", x => x.CartLineID);
                    table.ForeignKey(
                        name: "FK_CartLine_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartLine_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "RentalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentalDetails",
                columns: table => new
                {
                    RentalDetailId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    BikeID = table.Column<int>(type: "int", nullable: false),
                    RateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_RentalDetails_Bikes",
                        column: x => x.BikeID,
                        principalTable: "Bikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalDetails_RentalRates",
                        column: x => x.RateID,
                        principalTable: "RentalRates",
                        principalColumn: "RentalRateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalDetails_Rentals",
                        column: x => x.RateID,
                        principalTable: "Rentals",
                        principalColumn: "RentalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_FeatureId",
                table: "Bikes",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_RateId",
                table: "Bikes",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_BikesInShops_BikeId",
                table: "BikesInShops",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_BikesInShops_ShopId",
                table: "BikesInShops",
                column: "ShopId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_BikeId",
                table: "CartLine",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_RentalId",
                table: "CartLine",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShopId",
                table: "Employees",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetails_BikeID",
                table: "RentalDetails",
                column: "BikeID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetails_RateID",
                table: "RentalDetails",
                column: "RateID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_BikeId",
                table: "Rentals",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustId",
                table: "Rentals",
                column: "CustId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_PaymentStatusCodeNavigationPaymentStatusId",
                table: "Rentals",
                column: "PaymentStatusCodeNavigationPaymentStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikesInShops");

            migrationBuilder.DropTable(
                name: "BikeTypes");

            migrationBuilder.DropTable(
                name: "CartLine");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RentalDetails");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PaymentStatuses");

            migrationBuilder.DropTable(
                name: "RentalRates");

            migrationBuilder.DropTable(
                name: "SpecialFeatures");
        }
    }
}
