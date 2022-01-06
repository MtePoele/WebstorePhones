using Microsoft.EntityFrameworkCore.Migrations;

namespace WebstorePhones.Business.Migrations
{
    public partial class AttemptingToCreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[] { 1L, "Apple" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[] { 2L, "Samsung" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[] { 3L, "Nokia" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "BrandId", "Description", "PriceWithTax", "Stock", "Type" },
                values: new object[] { 1L, 1L, "Old phone", 100m, 0, "iPhone 1" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "BrandId", "Description", "PriceWithTax", "Stock", "Type" },
                values: new object[] { 2L, 2L, "Doesn't look like the night's sky.", 100m, 0, "Galaxy" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "BrandId", "Description", "PriceWithTax", "Stock", "Type" },
                values: new object[] { 3L, 3L, "Very old phone", 100m, 0, "3315" });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_BrandId",
                table: "Phones",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
