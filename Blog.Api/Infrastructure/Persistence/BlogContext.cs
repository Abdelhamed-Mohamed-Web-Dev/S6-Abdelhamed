using Microsoft.EntityFrameworkCore;

namespace Persistence
{
	public class BlogContext(DbContextOptions<BlogContext> options)
		: DbContext(options)
	{
	}
}
