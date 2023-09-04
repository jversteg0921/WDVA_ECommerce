using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WDVA_ECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixProductImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://i.etsystatic.com/11053806/r/il/7cde18/2538158495/il_794xN.2538158495_jaxu.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://i.etsystatic.com/22677717/r/il/357f5e/2651467674/il_794xN.2651467674_rsw8.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImgUrl",
                value: "https://i.etsystatic.com/11434562/r/il/25ef84/4448371220/il_794xN.4448371220_pd6o.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://storage.googleapis.com/loveable.appspot.com/medium_Personalized_Army_Shadow_Box_371ab9833b/medium_Personalized_Army_Shadow_Box_371ab9833b.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://storage.googleapis.com/loveable.appspot.com/medium_Flag_Landscape_Stone_c3c5791a37/medium_Flag_Landscape_Stone_c3c5791a37.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImgUrl",
                value: "https://storage.googleapis.com/loveable.appspot.com/medium_Soldiers_Creed_7ba30f947f/medium_Soldiers_Creed_7ba30f947f.webp");
        }
    }
}
