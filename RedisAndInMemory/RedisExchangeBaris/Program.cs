using RedisExchangeBaris.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add our redis service here
builder.Services.AddSingleton<RedisService>(provider =>
{
    // Create a new instance of RedisService, passing IConfiguration as a dependency.
    var redisService = new RedisService(provider.GetRequiredService<IConfiguration>());
    redisService.Connect();  // Call the Connect method when the service is created
    return redisService;
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
