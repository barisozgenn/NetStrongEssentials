using DomainDrivenDesign.Application;
using DomainDrivenDesign.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register Application layer services.
builder.Services.AddApplication();

// Register Infrastructure layer services.
builder.Services.AddInfrastructure();

// Add controllers to the service collection.
builder.Services.AddControllers();

// Register services for generating OpenAPI/Swagger documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve Swagger UI.
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS.

app.UseAuthorization(); // Enable authorization middleware.

// Map controller endpoints.
app.MapControllers();

// Run the application.
app.Run();