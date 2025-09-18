namespace Blog.Api.Extensions
{
	public static class InfrastructureExtensions
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<BlogContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultSqlConnection")));
			return services;
		}
		public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
			return services;
		}
	}
}
