using System.Collections.Immutable;
using System.Text;
using ApplicationCore.interfaces;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Email;
using ApplicationCore.Interfaces.Invoice;
using ApplicationDomain;
using ApplicationInfrastructure.EmailService;
using ApplicationInfrastructure.FileService;
using ApplicationInfrastructure.InoviceService;
using ApplicationPersistence.Context;
using ApplicationPersistence.Jwt;
using ApplicationPersistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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

            services.AddIdentity<User, IdentityRole>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<MyDbContext>()
            .AddDefaultTokenProviders();


            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = false,
                    ValidIssuer = configuration.GetSection("Jwt:Issuer").Get<string>(),
                    ValidAudience = configuration.GetSection("Jwt:Audience").Get<string>(),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]))
                };
            });

            // services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Two Ways to inject Service 1-if using DepartmentService to controller
            // OR Inject IDepartmentRepository and using CQRS way

            //frist way
            services.AddScoped<IDepartmentRepository, DepartmentReposiroty>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorDeptsRepository, DoctorDeptsRepository>();
            services.AddScoped<IAppointmentRepoistory, AppointmentRepository>();
            services.AddScoped<IEmail, EmailSender>();
            services.AddTransient<IEmailSender, ApplicationInfrastructure.EmailService.SendGrid>();

            services.AddScoped<IFile, FileService>();
            services.AddScoped<IInvoice, InvoiceService>();
            services.AddScoped<JwtService>();

            // second way
            // services.AddScoped<DepartmentReposiroty>();
            // services.AddScoped<DepartmentService>();


            return services;

        }
    }
}