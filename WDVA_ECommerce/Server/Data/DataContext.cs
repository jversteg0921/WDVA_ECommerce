
namespace WDVA_ECommerce.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().HasData(
					new Product
					{
						Id = 1,
						Title = "Shot Glass",
						Description = "This Shot Glass makes a perfect gift for any military veteran, active duty soldier, army navy air force, or marine. The perfect shot glass is made of glass and holds 2 oz of liquid, and is perfect for whiskey, vodka, tequila, rum, gin, espresso, or dessert.",
						ImgUrl = "https://storage.googleapis.com/loveable.appspot.com/medium_Shot_Glass_Gift_b8e35cf871/medium_Shot_Glass_Gift_b8e35cf871.jpg",
						Price = 10.99m,
					},
					new Product
					{
						Id = 2,
						Title = "Travel Tumbler Mug",
						Description = "Get this special travel mug for veteran in your life. This is the perfect gift that they'll appreciate and keep using for his entire life. Make it yourself or give one as a unique gift for someone you know.",
						ImgUrl = "https://storage.googleapis.com/loveable.appspot.com/medium_Travel_Tumbler_Mug_d4d5e10565/medium_Travel_Tumbler_Mug_d4d5e10565.jpg",
						Price = 18.99m,
					},
					new Product
					{
						Id = 3,
						Title = "Patriotic Box Sign",
						Description = "The best gift for your loved one is a wood box sign that features the sentiment 'heroes don't wear capes they wear dog tags,' and the design is perfect for you.",
						ImgUrl = "https://storage.googleapis.com/loveable.appspot.com/medium_Patriotic_Box_Sign_09a27ad5cf/medium_Patriotic_Box_Sign_09a27ad5cf.jpg",
						Price = 12.99m,
					},
					new Product
					{
						Id = 4,
						Title = "Personalized Army Shadow Box",
						Description = "The perfect gift for any military personnel, this Army Shadow Box is the perfect gift for any service member or anyone who respects those who serve us. It comes in a variety of sizes. The glass of the shadow box will be personalized with your Last Name.",
						ImgUrl = "https://storage.googleapis.com/loveable.appspot.com/medium_Personalized_Army_Shadow_Box_371ab9833b/medium_Personalized_Army_Shadow_Box_371ab9833b.webp",
						Price = 35.99m,
					},
					new Product
					{
						Id = 5,
						Title = "Flag Landscape Stone",
						Description = "This is a natural-looking boulder that's shaped just for you. It's personalized so that it fits perfectly in any setting. This round stone is the perfect addition to your home’s landscaping and your front lawn.",
						ImgUrl = "https://storage.googleapis.com/loveable.appspot.com/medium_Flag_Landscape_Stone_c3c5791a37/medium_Flag_Landscape_Stone_c3c5791a37.webp",
						Price = 85.99m,
					}

				);
		}

		public DbSet<Product> Products { get; set; }
	}
}
