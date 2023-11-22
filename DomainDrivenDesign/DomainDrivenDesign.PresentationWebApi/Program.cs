using DomainDrivenDesign.Application;
using DomainDrivenDesign.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add Application layer dependency
builder.Services.AddApplication();
//Add Infrastructure layer dependency
builder.Services.AddInfrastructure();

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
