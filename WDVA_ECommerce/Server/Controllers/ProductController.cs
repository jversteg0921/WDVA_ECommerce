using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WDVA_ECommerce.Shared.DTOs;

namespace WDVA_ECommerce.Server.Controllers
{
	/// <summary>
	/// Product Search and Retrieval
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
        {
			_productService=productService;
		}

		/// <summary>
		/// Gets a list of all products
		/// </summary>
		/// <returns></returns>
        [HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
		{
			var result = await _productService.GetProductsAsync();
			return Ok(result);
		}

		/// <summary>
		/// Gets a specific product
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		[HttpGet("{productId}")]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct(int productId)
		{
			var result = await _productService.GetProductAsync(productId);
			return Ok(result);
		}

		/// <summary>
		/// Gets a list of products by category
		/// </summary>
		/// <param name="categoryUrl"></param>
		/// <returns></returns>
		[HttpGet("category/{categoryUrl}")]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
		{
			var result = await _productService.GetProductsByCategoryAsync(categoryUrl);
			return Ok(result);
		}

		/// <summary>
		/// Search for a product, includes pagination
		/// </summary>
		/// <param name="searchText"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		[HttpGet("search/{searchText}/{page}")]
		public async Task<ActionResult<ServiceResponse<ProductSearchResultDTO>>> SearchProducts(string searchText, int page = 1)
		{
			var result = await _productService.SearchProducts(searchText, page);
			return Ok(result);
		}

		/// <summary>
		/// Gets suggestions for product search terms
		/// </summary>
		/// <param name="searchText"></param>
		/// <returns></returns>
		[HttpGet("searchsuggestions/{searchText}")]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
		{
			var result = await _productService.GetProductSearchSuggestions(searchText);
			return Ok(result);
		}

		/// <summary>
		/// Gets a list of featured products
		/// </summary>
		/// <returns></returns>
		[HttpGet("featured")]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
		{
			var result = await _productService.GetFeaturedProducts();
			return Ok(result);
		}
	}
}
