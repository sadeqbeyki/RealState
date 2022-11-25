using AppFramework.Application;
using EndPoint.WebUI;
using RS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
//_____________________________________________________________________________________________________
// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IFileUploader, FileUploader>();
var connectionString = builder.Configuration.GetConnectionString("RealStateDB");
ConfigureServices.Configure(builder.Services, connectionString);


var app = builder.Build();
//_____________________________________________________________________________________________________
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Admin",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
