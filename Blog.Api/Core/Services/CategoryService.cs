namespace Services
{
	public class CategoryService(IGenericRepository<Category, int> repository, IMapper mapper) : ICategoryService
	{
		public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
		{
			return mapper.Map<IEnumerable<CategoryDto>>(await repository.GetAllAsync());
		}
		public async Task<CategoryDto> GetCategoryByIdAsync(int id)
		{
			return mapper.Map<CategoryDto>(await repository.GetAsync(id));
		}
		public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
		{
			var cat = await repository.GetAsync(categoryDto.Id);
			if (cat is not null)
			{
				// already added >>>>>>>>>>>>>>>>>>>>>>>>
				return categoryDto;
			}
			var category = new Category()
			{
				Name = categoryDto.Name
			};
			await repository.AddAsync(category);
			await repository.SaveAsync();
			return categoryDto;
		}
		public async Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto)
		{
			var category = await repository.GetAsync(categoryDto.Id);
			if (category is null)
			{
				// NotFoundException >>>>>>>>>>>>>>>>>>>>>>>
				return categoryDto;
			}
			category.Name = categoryDto.Name;
			repository.Update(category);
			await repository.SaveAsync();
			return categoryDto;
		}
		public async Task<CategoryDto> DeleteCategoryAsync(int id)
		{
			var category = await repository.GetAsync(id);
			if (category is null)
			{
				// NotFoundException >>>>>>>>>>>>>>>>>>>>>>>
				return mapper.Map<CategoryDto>(category);
			}
			repository.Delete(category);
			await repository.SaveAsync();
			return mapper.Map<CategoryDto>(category);
		}

	}
}
