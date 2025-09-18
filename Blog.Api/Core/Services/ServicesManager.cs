namespace Services
{
	public class ServicesManager : IServicesManager
	{
		readonly Lazy<ICategoryService> _categoryService;
		readonly Lazy<IPostService> _postService;
		readonly Lazy<ICommentService> _commentService;

		public ServicesManager(
			IMapper mapper,
			IGenericRepository<Category, int> categoryRepository,
			IGenericRepository<Post, int> postRepository,
			IGenericRepository<Comment, int> commentRepository)
		{
			_categoryService = new Lazy<ICategoryService>(() => new CategoryService(categoryRepository, mapper));
			_postService = new Lazy<IPostService>(() => new PostService(postRepository, mapper));
			_commentService = new Lazy<ICommentService>(() => new CommentService(commentRepository, mapper));
		}

		public ICategoryService CategoryService() => _categoryService.Value;
		public IPostService PostService() => _postService.Value;
		public ICommentService CommentService() => _commentService.Value;
	}
}
