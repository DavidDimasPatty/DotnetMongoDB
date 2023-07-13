using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApi.Models;
using WebApi.Services;

public class MainApp
{
 public static void Main(string[] args)
{   
    DotNetEnv.Env.Load();
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.Configure<ranwebStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(ranwebStoreDatabaseSettings)));

    builder.Services.AddSingleton<IranwebStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ranwebStoreDatabaseSettings>>().Value);

    builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<String>("ranwebStoreDatabaseSettings:ConnectionString")));

    builder.Services.AddScoped<IranwebService, ranwebService>();

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();

    var app = builder.Build();

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