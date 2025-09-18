namespace Services
{
	public class PostService(IGenericRepository<Post, int> repository, IMapper mapper) : IPostService
	{
		public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
		{
			return mapper.Map<IEnumerable<PostDto>>(await repository.GetAllAsync());
		}
		public async Task<PostDto> GetPostByIdAsync(int id)
		{
			return mapper.Map<PostDto>(await repository.GetAsync(id));
		}
		public async Task<PostDto> AddPostAsync(PostDto postDto)
		{
			var p = await repository.GetAsync(postDto.Id);
			if (p is not null)
			{
				// already added >>>>>>>>>>>>>>>>>>>>>>>>
				return postDto;
			}
			var post = new Post()
			{
				Title = postDto.Title,
				Content = postDto.Content,
				CreatedAt = DateTime.UtcNow,
				CategoryId = postDto.CategoryId,
			};
			await repository.AddAsync(post);
			await repository.SaveAsync();
			return postDto;
		}
		public async Task<PostDto> UpdatePostAsync(PostDto postDto)
		{
			var post = await repository.GetAsync(postDto.Id);
			if (post is null)
			{
				// NotFoundException >>>>>>>>>>>>>>>>>>>>>>>
				return postDto;
			}

			post.Title = postDto.Title;
			post.Content = postDto.Content;
			post.CategoryId = postDto.CategoryId;

			repository.Update(post);
			await repository.SaveAsync();
			return postDto;
		}
		public async Task<PostDto> DeletePostAsync(int id)
		{
			var post = await repository.GetAsync(id);
			if (post is null)
			{
				// NotFoundException >>>>>>>>>>>>>>>>>>>>>>>
				return mapper.Map<PostDto>(post);
			}
			repository.Delete(post);
			await repository.SaveAsync();
			return mapper.Map<PostDto>(post);
		}
	}
}
