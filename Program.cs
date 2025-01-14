using Microsoft.EntityFrameworkCore;
using Proyecto_Practica02_.Data;

public class Program
  {
  private static void Main(string[] args)
    {
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddDbContext<DataBaseContext>(context =>
    {
      context.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    //Builder configuration

    builder.Configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();

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

    app.Run();
    }
  }