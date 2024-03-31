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

            // var MapperConfig = new MapperConfiguration(x =>
            // {
            //     x.AddProfile<DepartmentProfiles>();
            //     x.AddProfile<MappingProfiles>();
            //     x.AddProfile<AppointmentProfiles>();
            // });
            // IMapper Mapper = MapperConfig.CreateMapper();
            // services.AddSingleton<IMapper>(Mapper);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }

    }
}
