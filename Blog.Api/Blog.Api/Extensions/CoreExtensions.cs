using ServicesAbstraction;

namespace Blog.Api.Extensions
{
	public static class CoreExtensions
	{
		public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
			services.AddAutoMapper(_ => { }, typeof(AssemblyReference).Assembly);
			services.AddScoped<IServicesManager, ServicesManager>();

			return services;
		}
	}
}
