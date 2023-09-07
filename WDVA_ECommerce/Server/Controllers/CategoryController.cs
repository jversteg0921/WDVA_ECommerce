using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WDVA_ECommerce.Server.Controllers
{
	/// <summary>
	/// Category retrieval 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
        {
			_categoryService=categoryService;
		}

		/// <summary>
		/// Gets list of categories
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
		{
			var result = await _categoryService.GetCategoriesAsync();
			return Ok(result);
		}
    }
}
