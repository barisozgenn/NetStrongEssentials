using HealthChecks;
using HealthChecks.BackgroundServices;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHealthChecks()
    .AddSqlServer(
    connectionString: "myConnectionString",
    healthQuery: "Select 1",
    name: "Sql Server",
    failureStatus: HealthStatus.Unhealthy,
    tags: new String[] {"database","ourWhatWeNeedToCheck"});
builder.Services.AddHostedService<DatabaseHealthChecksService>();

builder.Services.AddControllers();
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

app.UseHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    //Predicate = check => check.Tags.Contains("database"),
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
