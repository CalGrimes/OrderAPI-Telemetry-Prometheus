using OpenTelemetry.Resources;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "ToolStore API",
        Version = "v1"
    });
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.RegisterInfrastureDependencies(builder.Configuration);

builder.Services.AddOpenTelemetry()
    .WithMetrics(MetricsBuilderExtensions =>
    {
        MetricsBuilderExtensions.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("TelemetryPrometheus"));
        MetricsBuilderExtensions.AddMeter("Microsoft.AspNetCore.Hosting");
        MetricsBuilderExtensions.AddMeter("Microsoft.AspNetCore.Server.Kestrel");
        MetricsBuilderExtensions.AddMeter("System.Net.Http");
        MetricsBuilderExtensions.AddMeter("Microsoft.AspNetCore.Routing");
        MetricsBuilderExtensions.AddMeter("Microsoft.AspNetCore.Diagnostics");
        MetricsBuilderExtensions.AddMeter("Microsoft.AspNetCore.RateLimiting");
        MetricsBuilderExtensions.AddPrometheusExporter();

        MetricsBuilderExtensions.AddOtlpExporter();
    });

builder.Logging.AddOpenTelemetry(options =>
{
    options.AddConsoleExporter();
    options.AddOtlpExporter();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
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
app.MapPrometheusScrapingEndpoint();
app.UseCors("AllowAllOrigins");

app.Run();
