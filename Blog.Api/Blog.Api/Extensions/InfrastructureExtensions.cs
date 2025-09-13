namespace Blog.Api.Extensions
{
	public static class InfrastructureExtensions
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<BlogContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultSqlConnection")));
			return services;
		}
	}
}
