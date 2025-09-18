namespace ServicesAbstraction
{
	public interface IServicesManager
	{
        public ICategoryService CategoryService();
        public IPostService PostService();
        public ICommentService CommentService();
    }
}
