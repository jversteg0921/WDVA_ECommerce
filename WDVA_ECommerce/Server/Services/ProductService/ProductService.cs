namespace WDVA_ECommerce.Server.Services.ProductService
{
	public class ProductService : IProductService
	{
		private readonly DataContext _context;

		public ProductService(DataContext context)
		{
			_context=context;
		}
		
		//Gets a single product from the database, based on productId
		public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
		{
			var response = new ServiceResponse<Product>();
			var product = await _context.Products.FindAsync(productId);

			if (product == null)
			{
				response.Success = false;
				response.Message = "Sorry, we couldn't find this product.";
			}
			else
			{
				response.Data = product;
			}
			return response;
		}

		//Gets all products from the database
		public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
		{
			var response = new ServiceResponse<List<Product>>
			{
				Data = await _context.Products.ToListAsync()
			};

			return response;
		}

		//Gets all products for a single category based on categoryUrl
		public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
		{
			var response = new ServiceResponse<List<Product>>
			{
				Data = await _context.Products
					.Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
					.ToListAsync()
			};

			return response;
		}

		//Gets search suggestions based on the enterd search text by looking through all product titles and descriptions.
		public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
		{
			var products = await FindProductsBySearchText(searchText);
			List<string> result = new List<string>();

			foreach (var product in products)
			{
				//Checks if the product title contains the search text
				if(product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
				{
					result.Add(product.Title);
				}

				//splits description by any punctuation into individual words.
				//checks if any of those words match the search text and adds to result (if not already in result list)
				if(product.Description != null)
				{
					var punctuation = product.Description.Where(char.IsPunctuation)
						.Distinct().ToArray();
					var words = product.Description.Split()
						.Select(s => s.Trim(punctuation));

					foreach(var word in words)
					{
						if(word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
							&& !result.Contains(word))
						{
							result.Add(word);
						}
					}
				}
			}

			return new ServiceResponse<List<string>>
			{
				Data = result
			};
		}

		public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
		{
			var response = new ServiceResponse<List<Product>>
			{
				Data = await FindProductsBySearchText(searchText)
			};

			return response;
		}

		private async Task<List<Product>> FindProductsBySearchText(string searchText)
		{
			return await _context.Products
								.Where(p => p.Title.ToLower().Contains(searchText.ToLower())
								|| p.Description.ToLower().Contains(searchText.ToLower()))
								.ToListAsync();
		}
	}
}
