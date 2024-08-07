using Clean.Api;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Clean API Starting");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
    .WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration));

var application = builder
    .ConfigureServices()
    .ConfigurePipeline();

application.UseSerilogRequestLogging();
application.MapGet("/", () => "Hello World!");
application.Run();

public partial class Program { }
