using cookie_stand_api.Data;
using cookie_stand_api.Models.Interface;
using cookie_stand_api.Models.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace cookie_stand_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services
                .AddDbContext<AppDbContext>
                (options => options.UseSqlServer(connString));

            builder.Services.AddTransient<ICookieStand, CookieStandService>();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "cookie_stand_api",
                    Version = "v1",
                });
            });

            var app = builder.Build();

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "cookie_stand_api");
                options.RoutePrefix = "docs";
            });

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}