
namespace WDVA_ECommerce.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CartItem>()
				.HasKey(ci => new {ci.UserId, ci.ProductId});

			modelBuilder.Entity<Product>().HasData(
					new Product
					{
						Id = 1,
						Title = "Shot Glass",
						Description = "This Shot Glass makes a perfect gift for any military veteran, active duty soldier, army navy air force, or marine. The perfect shot glass is made of glass and holds 2 oz of liquid, and is perfect for whiskey, vodka, tequila, rum, gin, espresso, or dessert.",
						ImgUrl = "https://storage.googleapis.com/loveable.appspot.com/medium_Shot_Glass_Gift_b8e35cf871/medium_Shot_Glass_Gift_b8e35cf871.jpg",
						Price = 10.99m,
						CategoryId = 1,
						Featured = true
					},
					new Product
					{
						Id = 2,
						Title = "Travel Tumbler Mug",
						Description = "Get this special travel mug for veteran in your life. This is the perfect gift that they'll appreciate and keep using for his entire life. Make it yourself or give one as a unique gift for someone you know.",
						ImgUrl = "https://storage.googleapis.com/loveable.appspot.com/medium_Travel_Tumbler_Mug_d4d5e10565/medium_Travel_Tumbler_Mug_d4d5e10565.jpg",
						Price = 18.99m,
						CategoryId = 1,
					},
					new Product
					{
						Id = 3,
						Title = "Patriotic Box Sign",
						Description = "The best gift for your loved one is a wood box sign that features the sentiment 'heroes don't wear capes they wear dog tags,' and the design is perfect for you.",
						ImgUrl = "https://storage.googleapis.com/loveable.appspot.com/medium_Patriotic_Box_Sign_09a27ad5cf/medium_Patriotic_Box_Sign_09a27ad5cf.jpg",
						Price = 12.99m,
						CategoryId = 3,
					},
					new Product
					{
						Id = 4,
						Title = "Personalized Army Shadow Box",
						Description = "The perfect gift for any military personnel, this Army Shadow Box is the perfect gift for any service member or anyone who respects those who serve us. It comes in a variety of sizes. The glass of the shadow box will be personalized with your Last Name.",
						ImgUrl = "https://i.etsystatic.com/11053806/r/il/7cde18/2538158495/il_794xN.2538158495_jaxu.jpg",
						Price = 35.99m,
						CategoryId = 2,
					},
					new Product
					{
						Id = 5,
						Title = "Flag Landscape Stone",
						Description = "This is a natural-looking boulder that's shaped just for you. It's personalized so that it fits perfectly in any setting. This round stone is the perfect addition to your home’s landscaping and your front lawn.",
						ImgUrl = "https://i.etsystatic.com/22677717/r/il/357f5e/2651467674/il_794xN.2651467674_rsw8.jpg",
						Price = 85.99m,
						CategoryId = 2,
						Featured = true
					},
					new Product
					{
						Id = 6,
						Title = "T-Shirt Veteran",
						Description = "This is a fun and unique gift for dads, grandpas, husbands, best dad ever, father's day, fathers day, birthday, valentine's day, mother's day, grandfather's day, birthdays, mothers' day, and other special occasions.",
						ImgUrl = "https://storage.googleapis.com/loveable.appspot.com/small_T_Shirt_Veteran_549e4a8960/small_T_Shirt_Veteran_549e4a8960.jpg",
						Price = 15.25m,
						CategoryId = 4,
					},
					new Product
					{
						Id = 7,
						Title = "USMC Pint Glass",
						Description = "If you’re looking for the perfect gift for a veteran or any special Marine, give the one who served and served with style by choosing one of these amazing Marine Graduation gifts and Veteran Gifts that feature the best of their military career!",
						ImgUrl = "https://storage.googleapis.com/loveable.appspot.com/medium_USMC_Pint_Glass_ff94bd4a3f/medium_USMC_Pint_Glass_ff94bd4a3f.jpg",
						Price = 15.25m,
						CategoryId = 1,
						Featured = true
					},
					new Product
					{
						Id = 8,
						Title = "American Flag",
						Description = "This is must-have wall art! It is a gallery-wrapped canvas that was then custom-built around the artwork using UV-resistant, semi-gloss archival coating that protects the print from fading.",
						ImgUrl = "https://storage.googleapis.com/loveable.appspot.com/small_American_Flag_1fa6e1a101/small_American_Flag_1fa6e1a101.jpg",
						Price = 35.25m,
						CategoryId = 2,
					},
					new Product
					{
						Id = 9,
						Title = "Soldiers Creed",
						Description = "This is an amazing piece by the US Army about their soldier's creed! It is the perfect Christmas gift for both current army soldiers and veterans. Each of our steel pieces is carefully cut and polished and uses state-of-the-art equipment to laser etch the piece.",
						ImgUrl = "https://i.etsystatic.com/11434562/r/il/25ef84/4448371220/il_794xN.4448371220_pd6o.jpg",
						Price = 24.95m,
						CategoryId = 3,
					}

				);

			modelBuilder.Entity<Category>().HasData(
					new Category
					{
						Id = 1,
						Name = "Cups",
						Url = "cups"
					},
					new Category
					{
						Id=2,
						Name="Flags",
						Url="flags"
					},
					new Category
					{
						Id=3,
						Name="Signs",
						Url="signs"
					},
					new Category
					{
						Id=4,
						Name="Clothing",
						Url="clothing"
					}
				);
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
	}
}
