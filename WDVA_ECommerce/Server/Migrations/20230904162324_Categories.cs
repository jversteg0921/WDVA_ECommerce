using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WDVA_ECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Cups", "cups" },
                    { 2, "Flags", "flags" },
                    { 3, "Signs", "signs" },
                    { 4, "Clothing", "clothing" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImgUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 6, 4, "This is a fun and unique gift for dads, grandpas, husbands, best dad ever, father's day, fathers day, birthday, valentine's day, mother's day, grandfather's day, birthdays, mothers' day, and other special occasions.", "https://storage.googleapis.com/loveable.appspot.com/small_T_Shirt_Veteran_549e4a8960/small_T_Shirt_Veteran_549e4a8960.jpg", 15.25m, "T-Shirt Veteran" },
                    { 7, 1, "If you’re looking for the perfect gift for a veteran or any special Marine, give the one who served and served with style by choosing one of these amazing Marine Graduation gifts and Veteran Gifts that feature the best of their military career!", "https://storage.googleapis.com/loveable.appspot.com/medium_USMC_Pint_Glass_ff94bd4a3f/medium_USMC_Pint_Glass_ff94bd4a3f.jpg", 15.25m, "USMC Pint Glass" },
                    { 8, 2, "This is must-have wall art! It is a gallery-wrapped canvas that was then custom-built around the artwork using UV-resistant, semi-gloss archival coating that protects the print from fading.", "https://storage.googleapis.com/loveable.appspot.com/small_American_Flag_1fa6e1a101/small_American_Flag_1fa6e1a101.jpg", 35.25m, "American Flag" },
                    { 9, 3, "This is an amazing piece by the US Army about their soldier's creed! It is the perfect Christmas gift for both current army soldiers and veterans. Each of our steel pieces is carefully cut and polished and uses state-of-the-art equipment to laser etch the piece.", "https://storage.googleapis.com/loveable.appspot.com/medium_Soldiers_Creed_7ba30f947f/medium_Soldiers_Creed_7ba30f947f.webp", 24.95m, "Soldiers Creed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");
        }
    }
}
