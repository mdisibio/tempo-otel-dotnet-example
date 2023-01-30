using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace app;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddOpenTelemetry()
            .ConfigureResource(r => r.AddService("dotnet6-example"))
            .WithTracing(builder => builder
                .AddAspNetCoreInstrumentation()
                .AddConsoleExporter()
                .AddOtlpExporter()
            )
            .StartWithHost();         


        var app = builder.Build();
        app.MapGet("/weather", getForecast);
        app.Run();
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static IEnumerable<WeatherForecast> getForecast()
    {
        Console.WriteLine($"Getting weather forecast traceID={Activity.Current?.TraceId}");
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        });
    }
}
