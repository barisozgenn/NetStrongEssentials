using IoCBaris;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Add services to the container. in program.cs for net >= 6 else startup cs
//builder.Services.AddSingleton<IoCManualExample>();

//builder.Services.AddSingleton<ConsoleLog>(); //NOT: new T() without parameter;
//builder.Services.AddSingleton<ConsoleLog>(new ConsoleLog(5)); //NOT: new T(int) with parameter;

builder.Services.AddTransient<ConsoleLog>();//NOT: new T() without parameter;
builder.Services.AddTransient<ConsoleLog>(p=> new ConsoleLog(4));//NOT: new T(int) with parameter;
builder.Services.AddTransient<ILog>(p=> new ConsoleLog(4));//NOT: new T(int) with parameter;

builder.Services.AddScoped<ILog>(p => new TextLog());
builder.Services.AddScoped<ILog, TextLog>();


app.MapGet("/", () => "Hello World!");

app.Run();
