namespace ServicesAbstraction
{
	public interface ICommentService
	{
		Task<IEnumerable<CommentDto>> GetAllCommentsAsync();
		Task<CommentDto> GetCommentByIdAsync(int id);
		Task<CommentDto> AddCommentAsync(CommentDto commentDto);
		Task<CommentDto> UpdateCommentAsync(CommentDto commentDto);
		Task<CommentDto> DeleteCommentAsync(int id);
	}
}
