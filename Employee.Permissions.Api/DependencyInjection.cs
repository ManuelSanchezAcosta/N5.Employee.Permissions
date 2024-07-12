using Employee.Permissions.Api.Middlewares;

namespace Employee.Permissions.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<GloblalExceptionHandlingMiddleware>();
            return services;
        }
    }
}
