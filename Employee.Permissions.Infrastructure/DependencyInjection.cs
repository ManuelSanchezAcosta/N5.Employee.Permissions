using Employee.Permissions.Application.Data;
using Employee.Permissions.Domain.Interfaces.Repositories.Commands;
using Employee.Permissions.Domain.Interfaces.Repositories.Queries;
using Employee.Permissions.Domain.Primitives;
using Employee.Permissions.Infrastructure.Persistence;
using Employee.Permissions.Infrastructure.Persistence.Repositories.Commands;
using Employee.Permissions.Infrastructure.Persistence.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Employee.Permissions.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddScoped<IApplicationDbContext>(sp =>
                    sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp =>
                    sp.GetRequiredService<ApplicationDbContext>());

            //QUERIES
            services.AddScoped<IEmployeeRepositoryQuery, EmployeeRepositoryQuery>();
            services.AddScoped<IPermissionRepositoryQuery, PermissionRepositoryQuery>();
            services.AddScoped<IPermissionTypeRepositoryQuery, PermissionTypeRepositoryQuery>();

            //COMMANDS
            services.AddScoped<IEmployeeRepositoryCommand, EmployeeRepositoryCommand>();
            services.AddScoped<IPermissionRepositoryCommand, PermissionRepositoryCommand>();
            services.AddScoped<IPermissionTypeRepositoryCommand, PermissionTypeRepositoryCommand>();

            return services;
        }
    }
}
