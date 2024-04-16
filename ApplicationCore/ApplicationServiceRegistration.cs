using ApplicationCore.Mapping;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApplicationCore
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplictionCoreService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }

    }
}
