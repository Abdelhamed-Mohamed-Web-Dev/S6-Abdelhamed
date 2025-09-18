namespace Presentation
{
	public class PostsController(IServicesManager servicesManager) : BaseController
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
			=> Ok(await servicesManager.PostService().GetAllPostsAsync());
		[HttpGet("{id}")]
		public async Task<ActionResult<PostDto>> GetPost(int id)
			=> Ok(await servicesManager.PostService().GetPostByIdAsync(id));
		[HttpPost]
		public async Task<ActionResult<PostDto>> AddPost(PostDto post)
			=> Ok(await servicesManager.PostService().AddPostAsync(post));
		[HttpPut]
		public async Task<ActionResult<PostDto>> UpdatePost(PostDto post)
			=> Ok(await servicesManager.PostService().UpdatePostAsync(post));
		[HttpDelete("{id}")]
		public async Task<ActionResult<PostDto>> DeletePost(int id)
			=> Ok(await servicesManager.PostService().DeletePostAsync(id));
	}
}
