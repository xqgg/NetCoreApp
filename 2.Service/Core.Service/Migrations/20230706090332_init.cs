using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Service.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "SalesOrderDetail",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(type: "int", nullable: false, comment: "Primary key. Foreign key to SalesOrderHeader.SalesOrderID."),
                    SalesOrderDetailID = table.Column<int>(type: "int", nullable: false, comment: "Primary key. One incremental unique number per product sold.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierTrackingNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "Shipment tracking number supplied by the shipper."),
                    OrderQty = table.Column<short>(type: "smallint", nullable: false, comment: "Quantity ordered per product."),
                    ProductID = table.Column<int>(type: "int", nullable: false, comment: "Product sold to customer. Foreign key to Product.ProductID."),
                    SpecialOfferID = table.Column<int>(type: "int", nullable: false, comment: "Promotional code. Foreign key to SpecialOffer.SpecialOfferID."),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false, comment: "Selling price of a single product."),
                    UnitPriceDiscount = table.Column<decimal>(type: "money", nullable: false, comment: "Discount amount."),
                    LineTotal = table.Column<decimal>(type: "numeric(38,6)", nullable: false, computedColumnSql: "(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", stored: false, comment: "Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty."),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated."),
                    ID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Enable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID", x => new { x.SalesOrderID, x.SalesOrderDetailID });
                },
                comment: "Individual products associated with a specific sales order. See SalesOrderHeader.");

            migrationBuilder.CreateTable(
                name: "T_Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Enable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Books", x => x.ID);
                    table.CheckConstraint("CK_Book_Price", "[Price] > 0");
                });

            migrationBuilder.CreateTable(
                name: "T_Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Enable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Enable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Users", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderDetail_rowguid",
                schema: "Sales",
                table: "SalesOrderDetail",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Users_Email",
                table: "T_Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_Users_Name",
                table: "T_Users",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_Users_PhoneNumber",
                table: "T_Users",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesOrderDetail",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "T_Books");

            migrationBuilder.DropTable(
                name: "T_Role");

            migrationBuilder.DropTable(
                name: "T_Users");
        }
    }
}
