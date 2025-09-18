namespace Presentation
{
	public class CommentsController(IServicesManager servicesManager) : BaseController
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CommentDto>>> GetAllComments()
			=> Ok(await servicesManager.CommentService().GetAllCommentsAsync());
		[HttpGet("{id}")]
		public async Task<ActionResult<CommentDto>> GetComment(int id)
			=> Ok(await servicesManager.CommentService().GetCommentByIdAsync(id));
		[HttpPost]
		public async Task<ActionResult<CommentDto>> AddComment(CommentDto comment)
			=> Ok(await servicesManager.CommentService().AddCommentAsync(comment));
		[HttpPut]
		public async Task<ActionResult<CommentDto>> UpdateComment(CommentDto comment)
			=> Ok(await servicesManager.CommentService().UpdateCommentAsync(comment));
		[HttpDelete("{id}")]
		public async Task<ActionResult<CommentDto>> DeleteComment(int id)
			=> Ok(await servicesManager.CommentService().DeleteCommentAsync(id));
	}
}
