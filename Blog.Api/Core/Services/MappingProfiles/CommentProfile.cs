namespace Services.MappingProfiles
{
	public class CommentProfile: Profile
	{
        public CommentProfile()
        {
            CreateMap<Comment,CommentDto>().ReverseMap();
        }
    }
}
