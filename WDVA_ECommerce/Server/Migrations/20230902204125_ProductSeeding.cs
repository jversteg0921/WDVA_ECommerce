using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WDVA_ECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "This Shot Glass makes a perfect gift for any military veteran, active duty soldier, army navy air force, or marine. The perfect shot glass is made of glass and holds 2 oz of liquid, and is perfect for whiskey, vodka, tequila, rum, gin, espresso, or dessert.", "https://storage.googleapis.com/loveable.appspot.com/medium_Shot_Glass_Gift_b8e35cf871/medium_Shot_Glass_Gift_b8e35cf871.jpg", 10.99m, "Shot Glass" },
                    { 2, "Get this special travel mug for veteran in your life. This is the perfect gift that they'll appreciate and keep using for his entire life. Make it yourself or give one as a unique gift for someone you know.", "https://storage.googleapis.com/loveable.appspot.com/medium_Travel_Tumbler_Mug_d4d5e10565/medium_Travel_Tumbler_Mug_d4d5e10565.jpg", 18.99m, "Travel Tumbler Mug" },
                    { 3, "The best gift for your loved one is a wood box sign that features the sentiment 'heroes don't wear capes they wear dog tags,' and the design is perfect for you.", "https://storage.googleapis.com/loveable.appspot.com/medium_Patriotic_Box_Sign_09a27ad5cf/medium_Patriotic_Box_Sign_09a27ad5cf.jpg", 12.99m, "Patriotic Box Sign" },
                    { 4, "The perfect gift for any military personnel, this Army Shadow Box is the perfect gift for any service member or anyone who respects those who serve us. It comes in a variety of sizes. The glass of the shadow box will be personalized with your Last Name.", "https://storage.googleapis.com/loveable.appspot.com/medium_Personalized_Army_Shadow_Box_371ab9833b/medium_Personalized_Army_Shadow_Box_371ab9833b.webp", 35.99m, "Personalized Army Shadow Box" },
                    { 5, "This is a natural-looking boulder that's shaped just for you. It's personalized so that it fits perfectly in any setting. This round stone is the perfect addition to your home’s landscaping and your front lawn.", "https://storage.googleapis.com/loveable.appspot.com/medium_Flag_Landscape_Stone_c3c5791a37/medium_Flag_Landscape_Stone_c3c5791a37.webp", 85.99m, "Flag Landscape Stone" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
