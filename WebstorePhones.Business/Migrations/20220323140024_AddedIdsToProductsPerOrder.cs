using Microsoft.EntityFrameworkCore.Migrations;

namespace WebstorePhones.Business.Migrations
{
    public partial class AddedIdsToProductsPerOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPerOrders_Orders_OrderId",
                table: "ProductsPerOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPerOrders_Phones_PhoneId",
                table: "ProductsPerOrders");

            migrationBuilder.AlterColumn<long>(
                name: "PhoneId",
                table: "ProductsPerOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPerOrders_Phones_PhoneId",
                table: "ProductsPerOrders",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPerOrders_Orders_OrderId",
                table: "ProductsPerOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPerOrders_Phones_PhoneId",
                table: "ProductsPerOrders");

            migrationBuilder.AlterColumn<long>(
                name: "PhoneId",
                table: "ProductsPerOrders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPerOrders_Phones_PhoneId",
                table: "ProductsPerOrders",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
