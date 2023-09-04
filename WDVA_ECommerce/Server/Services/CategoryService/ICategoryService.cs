namespace WDVA_ECommerce.Server.Services.CategoryService
{
	public interface ICategoryService
	{
		Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
	}
}
