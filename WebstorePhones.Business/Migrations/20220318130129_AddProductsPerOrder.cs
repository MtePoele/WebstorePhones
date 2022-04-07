using Microsoft.EntityFrameworkCore.Migrations;

namespace WebstorePhones.Business.Migrations
{
    public partial class AddProductsPerOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsPerOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsPerOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsPerOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsPerOrders_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsPerOrders_OrderId",
                table: "ProductsPerOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsPerOrders_PhoneId",
                table: "ProductsPerOrders",
                column: "PhoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsPerOrders");
        }
    }
}
