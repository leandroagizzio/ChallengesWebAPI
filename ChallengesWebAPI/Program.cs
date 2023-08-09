
using ChallengesWebAPI.Data;
using ChallengesWebAPI.Repositories.Interfaces;
using ChallengesWebAPI.Repositories;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ChallengesWebAPI
{
    public class Program
    {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(o =>
                o.UseSqlite(builder.Configuration.GetConnectionString("DataBaseSqLite"))
            );

            builder.Services.AddScoped<IChallengeRepository, ChallengeRepository>();
            builder.Services.AddScoped<IExecutionRepository, ExecutionRepository>();
            builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();

            // to object cycles error
            builder.Services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}