using LabAPBD_Test2.Data;
using LabAPBD_Test2.Services;
using Microsoft.EntityFrameworkCore;

namespace LabAPBD_Test2;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        // Added: Database context configuration
        builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
        );

        // Added: Dependency injection
        builder.Services.AddScoped<INurseriesService, NurseriesService>();
        builder.Services.AddScoped<IBatchesService, BatchesService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        /*app.UseHttpsRedirection();*/

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}