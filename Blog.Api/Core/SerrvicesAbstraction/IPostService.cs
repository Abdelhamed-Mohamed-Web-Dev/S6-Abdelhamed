namespace ServicesAbstraction
{
	public interface IPostService
	{
		Task<IEnumerable<PostDto>> GetAllPostsAsync();
		Task<PostDto> GetPostByIdAsync(int id);
		Task<PostDto> AddPostAsync(PostDto postDto);
		Task<PostDto> UpdatePostAsync(PostDto postDto);
		Task<PostDto> DeletePostAsync(int id);
	}
}
