using E_mart_final_project.models;
using Microsoft.EntityFrameworkCore;

namespace Emart
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            var b = builder.Configuration.GetConnectionString("key");
            builder.Services.AddDbContextPool<EmartContext>((op) => op.UseSqlServer(b));
            builder.Services.AddCors((p) => p.AddDefaultPolicy(
                                                policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors();
            app.Run();
            
        }
    }
}