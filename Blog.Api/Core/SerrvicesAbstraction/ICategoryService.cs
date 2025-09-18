namespace ServicesAbstraction
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
		Task<CategoryDto> GetCategoryByIdAsync(int id);
		Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto);
		Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto);
		Task<CategoryDto> DeleteCategoryAsync(int id);
	}
}
