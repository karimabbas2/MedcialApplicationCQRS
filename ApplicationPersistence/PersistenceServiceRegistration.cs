using ApplicationCore.interfaces;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Email;
using ApplicationCore.Interfaces.Invoice;
using ApplicationInfrastructure.EmailService;
using ApplicationInfrastructure.InoviceService;
using ApplicationPersistence.Context;
using ApplicationPersistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace medicalapp.ApplicationPersistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
   IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("myConn"), b => b.MigrationsAssembly("MedicalApplication.Server"));
                // options.UseSqlServer("myConn", b => b.MigrationsAssembly("MedicalApplication.Server"));

            });
            

            // services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Two Ways to inject Service 1-if using DepartmentService to controller
            // OR Inject IDepartmentRepository and using CQRS way

            //frist way
            services.AddScoped<IDepartmentRepository, DepartmentReposiroty>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorDeptsRepository,DoctorDeptsRepository>();
            services.AddScoped<IEmail,EmailSender>();
            services.AddScoped<IInvoice,InvoiceService>();
            services.AddScoped<IAppointmentRepoistory,AppointmentRepository>();

            // second way
            // services.AddScoped<DepartmentReposiroty>();
            // services.AddScoped<DepartmentService>();


            return services;

        }
    }
}