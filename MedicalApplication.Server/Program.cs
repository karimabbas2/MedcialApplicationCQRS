using ApplicationPersistence;
using ApplicationPersistence.Repositories;
using ApplicationPersistence.Services;
using medicalapp.ApplicationPersistence;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ApplicationCore;
using Microsoft.OpenApi.Models;
using SchoolProject.Api.Middleware;
using Serilog;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

////Allow_Origins
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithMethods("POST", "GET", "PUT", "DELETE").WithHeaders(HeaderNames.ContentType);
    });
});

///Add Authenticate Swagger Button
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter your Vaild Token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddPersistenceServices(builder.Configuration);

// ApplicationServiceRegistration.AddApplictionCoreService(builder.Services);
builder.Services.AddApplictionCoreService();
// Class1.AddMyMethod(builder.Services,builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Policy
builder.Services.AddAuthorizationBuilder()
            //Policy Based on Role
            .AddPolicy("AdminPolicy", policy => policy.RequireRole("admin"))
            //Policy Based On Claim
            .AddPolicy("PaitentHaveNumber", policy => policy.RequireClaim("PatientPhone"))
            //Policy Based On Claim with specific vlalue
            .AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "admin"))

            //Cusome Policy 
            .AddPolicy("PaitentsOlderThan25", policy => policy.RequireAssertion(context =>
            {
                var date = DateTime.Parse(context.User.FindFirstValue("DateOFBirth"));
                return DateTime.Today.Year - date.Year >= 20;
            }));


//Serilog
// Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
// builder.Services.AddSerilog();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
