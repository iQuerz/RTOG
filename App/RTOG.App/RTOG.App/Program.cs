using RTOG.App.Hubs;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;

builder.Configuration.SetBasePath(env.ContentRootPath)
                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables()
                     .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

//builder.Services.AddSingleton<HubData>();

//Business Layer
RTOG.Business.Extensions.StartupExtensions.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Login}");
});

app.MapHub<LobbyHub>("/Hubs/Lobby");
app.MapHub<GameHub>("/Hubs/Game");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");
app.MapRazorPages();
app.Run();
