
using FootballSystem.Api.Middleware;
using FootballSystem.Application.Interfaces;
using FootballSystem.Application.Mapping;
using FootballSystem.Application.Services;
using FootballSystem.Domain.Interfaces;
using FootballSystem.Infrastructure.Data;
using FootballSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FootballSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<FootballContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
            builder.Services.AddScoped<IPlayerService, PlayerService>();
            builder.Services.AddTransient<GlobalExceptionMiddleware>();
            builder.Services.AddAutoMapper(typeof(PlayerProfile));

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<GlobalExceptionMiddleware>();

            using(var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<FootballContext>();
                FootballContext.SeedData(db);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowFrontend");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
