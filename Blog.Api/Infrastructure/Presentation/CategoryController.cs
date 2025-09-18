namespace Presentation
{
	public class CategoriesController(IServicesManager servicesManager) : BaseController
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
			=> Ok(await servicesManager.CategoryService().GetAllCategoriesAsync());
		[HttpGet("{id}")]
		public async Task<ActionResult<CategoryDto>> GetCategory(int id)
			=> Ok(await servicesManager.CategoryService().GetCategoryByIdAsync(id));
		[HttpPost]
		public async Task<ActionResult<CategoryDto>> AddCategory(CategoryDto category)
			=> Ok(await servicesManager.CategoryService().AddCategoryAsync(category));
		[HttpPut]
		public async Task<ActionResult<CategoryDto>> UpdateCategory(CategoryDto category)
			=> Ok(await servicesManager.CategoryService().UpdateCategoryAsync(category));
		[HttpDelete("{id}")]
		public async Task<ActionResult<CategoryDto>> DeleteCategory(int id)
			=> Ok(await servicesManager.CategoryService().DeleteCategoryAsync(id));
	}
}
