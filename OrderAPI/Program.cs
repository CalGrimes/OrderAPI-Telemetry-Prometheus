using Microsoft.Extensions.Diagnostics.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using TelemetryPrometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetry()
    .WithMetrics(MetricsBuilderExtensions =>
    {
        MetricsBuilderExtensions.AddMeter("Microsoft.AspNetCore.Hosting");
        MetricsBuilderExtensions.AddMeter("Microsoft.AspNetCore.Server.Kestrel");
        MetricsBuilderExtensions.AddMeter("System.Net.Http");
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


builder.Services.AddSingleton<OrderRepository>();


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
