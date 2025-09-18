namespace Services.MappingProfiles
{
	public class CategoryProfile : Profile
	{
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
