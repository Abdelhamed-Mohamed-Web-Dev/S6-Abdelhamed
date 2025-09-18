namespace Services
{
	public class CommentService(IGenericRepository<Comment, int> repository, IMapper mapper) : ICommentService
	{
		public async Task<IEnumerable<CommentDto>> GetAllCommentsAsync()
		{
			return mapper.Map<IEnumerable<CommentDto>>(await repository.GetAllAsync());
		}
		public async Task<CommentDto> GetCommentByIdAsync(int id)
		{
			return mapper.Map<CommentDto>(await repository.GetAsync(id));
		}
		public async Task<CommentDto> AddCommentAsync(CommentDto commentDto)
		{
			var p = await repository.GetAsync(commentDto.Id);
			if (p is not null)
			{
				// already added >>>>>>>>>>>>>>>>>>>>>>>>
				return commentDto;
			}
			var comment = new Comment()
			{
				Content = commentDto.Content,
				CreatedAt = DateTime.UtcNow,
				PostId = commentDto.Id,
			};
			await repository.AddAsync(comment);
			await repository.SaveAsync();
			return commentDto;
		}
		public async Task<CommentDto> UpdateCommentAsync(CommentDto commentDto)
		{
			var comment = await repository.GetAsync(commentDto.Id);
			if (comment is null)
			{
				// NotFoundException >>>>>>>>>>>>>>>>>>>>>>>
				return commentDto;
			}

			comment.Content = commentDto.Content;

			repository.Update(comment);
			await repository.SaveAsync();
			return commentDto;
		}
		public async Task<CommentDto> DeleteCommentAsync(int id)
		{
			var comment = await repository.GetAsync(id);
			if (comment is null)
			{
				// NotFoundException >>>>>>>>>>>>>>>>>>>>>>>
				return mapper.Map<CommentDto>(comment);
			}
			repository.Delete(comment);
			await repository.SaveAsync();
			return mapper.Map<CommentDto>(comment);
		}
	}
}
