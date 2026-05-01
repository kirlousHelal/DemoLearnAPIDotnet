using Day3.Data;
using Day3.Models;
using Day3.Repository;
using Day3.Repository.unit_of_work;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Day3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //builder.Services.AddControllers().AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling
            //= Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            builder.Services.AddDbContext<LearnApiContext>
            (
                op => op.UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration
                .GetConnectionString("DefaultConnection"))
            );


            // // Normal Dependency Injection (DI)
            // builder.Services.AddScoped<StudentRepositoryDI>();
            // // Dependency Inversion Principle (DIP) 
            // builder.Services.AddScoped<IStudentReopsitory, StudentRepositoryDIP>();
            // Generic Dependency Injection (GDI)
            // builder.Services.AddScoped<StudentGenericRepository<Student>>();
            // Unit of Work (UoW)
            builder.Services.AddScoped<UnitOfWork>();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Day3 API",
                    Description = "ASP.NET Core Web API"
                });
            });


            builder.Services
            .AddAuthentication(op => op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                option =>
                {
                    String secertKey = "Hello My Name Is kiro And I love u All";
                    var encodedSecretKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(secertKey));
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        IssuerSigningKey = encodedSecretKey,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true
                    };
                });




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Day3 API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}


