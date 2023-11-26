using DependencyInjectionBaris;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<ICreateRandomNumberSingleton, CreateRandomNumberSingleton>();
builder.Services.AddScoped<ICreateRandomNumberScoped, CreateRandomNumberScoped>();
builder.Services.AddScoped<ICreateRandomNumberScoped2, CreateRandomNumberScoped2>();
builder.Services.AddTransient<ICreateRandomNumberTransient, CreateRandomNumberTransient>();

var app = builder.Build();

app.MapControllers();
app.Run();
