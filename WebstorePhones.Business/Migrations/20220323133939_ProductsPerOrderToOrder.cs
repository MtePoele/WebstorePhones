using Microsoft.EntityFrameworkCore.Migrations;

namespace WebstorePhones.Business.Migrations
{
    public partial class ProductsPerOrderToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPerOrders_Orders_OrderId",
                table: "ProductsPerOrders");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "ProductsPerOrders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPerOrders_Orders_OrderId",
                table: "ProductsPerOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPerOrders_Orders_OrderId",
                table: "ProductsPerOrders");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "ProductsPerOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPerOrders_Orders_OrderId",
                table: "ProductsPerOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
