
using Hw5CustomMiddlewares.Data;
using Hw5CustomMiddlewares.Middleware;
using Hw5CustomMiddlewares.Repository.Abstract;
using Hw5CustomMiddlewares.Repository.Concrete;
using Hw5CustomMiddlewares.Service.Abstract;
using Hw5CustomMiddlewares.Service.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Hw5CustomMiddlewares
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
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.LicenseKey = builder.Configuration["AutoMapper:LicenseKey"]!;
            }, typeof(Program).Assembly);

            var connectionString = builder.Configuration.GetConnectionString("AirplaneManagerConnection");
            builder.Services.AddDbContext<AirplaneManagerContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IAirplaneManagerRepository, AirplaneManagerRepository>();
            builder.Services.AddScoped<IAirplaneManagerService, AirplaneManagerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
