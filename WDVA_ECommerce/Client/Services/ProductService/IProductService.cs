namespace WDVA_ECommerce.Client.Services.ProductService
{
	public interface IProductService
	{
		List<Product> Products { get; set; }

		event Action ProductsChanged;
		string Message { get; set; }

		//optional argument of categoryUrl, if null we return all Products. Otherwise return products with matching category
		Task GetProducts(string? categoryUrl = null);
		Task<ServiceResponse<Product>> GetProduct(int productId);
		Task SearchProducts(string searchText);
		Task<List<string>> GetProductSearchSuggestions(string searchText);

	}
}
