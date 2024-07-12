using Employee.Permissions.Application.Common.Behaviors;
using Employee.Permissions.Application.Services;
using Employee.Permissions.Domain.Interfaces.QueueServices;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Permissions.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            });

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>)
            );

            services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

            services.AddScoped<IPublishInQueue, PublishInKafka>();

            return services;
        }
    }
}
