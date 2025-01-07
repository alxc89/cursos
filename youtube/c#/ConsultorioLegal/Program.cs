using ConsultorioLegal.Configuration;
using ConsultorioLegal.Configurations;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDatabaseConfiguration();
        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddFluentValidationConfiguration();

        builder.Services.AddAutoMapperConfiguration();
        builder.Services.AddDependecyInjectionConfiguration();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerConfiguration();
        builder.Host.UseSerilog();

        var app = builder.Build();

        app.UseExceptionHandler("/error");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseDataBaseConfiguration();
        app.UseSwaggerConfiguration();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        IConfigurationRoot configuration = GetConfiguration();
        ConfigurationLog(configuration);

        try
        {
            Log.Information("Iniciando o WebApi");
            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Erro catastrófico");
            throw;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static void ConfigurationLog(IConfigurationRoot configuration)
    {
        Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
    }

    private static IConfigurationRoot GetConfiguration()
    {
        string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{ambiente}.json", optional: true)
            .Build();
        return configuration;
    }
}