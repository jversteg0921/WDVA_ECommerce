namespace WDVA_ECommerce.Client.Services.CategoryService
{
	public interface ICategoryService
	{
        List<Category> Categories { get; set; }
		Task GetCategories();
    }
}
