namespace Services.MappingProfiles
{
	public class PostProfile : Profile
	{
        public PostProfile()
        {
            CreateMap<Post,PostDto>().ReverseMap();
        }
    }
}
