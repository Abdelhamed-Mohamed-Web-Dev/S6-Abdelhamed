namespace Persistence
{
	public class BlogContext(DbContextOptions<BlogContext> options)
		: DbContext(options)
	{
		public DbSet<Post> Posts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configs
			// Post
			modelBuilder.Entity<Post>(e =>
			{
				e.Property(c => c.Content).HasMaxLength(300);
				e.Property(c => c.Title).HasMaxLength(50);
			});
			// Comment
			modelBuilder.Entity<Comment>(e => e.Property(c => c.Content).HasMaxLength(200));
			// Category
			modelBuilder.Entity<Category>(e => e.Property(c => c.Name).HasMaxLength(100));
		}
	}
}
