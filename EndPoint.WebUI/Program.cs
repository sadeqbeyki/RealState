using AppFramework.Application;
using EndPoint.WebUI;
using EndPoint.WebUI.Areas.Admin.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
//_____________________________________________________________________________________________________
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddIdentity<AppUser, AppIdentityRole>(i =>
{
    i.User.RequireUniqueEmail = true;
    //c.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnmPOIUYTREWQLKJHGFDSAMNBVCXZ";
    i.Password.RequireDigit = false;
    i.Password.RequiredLength = 6;
    i.Password.RequireNonAlphanumeric = false;
    i.Password.RequireUppercase = false;
    i.Password.RequiredUniqueChars = 1;
    i.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<UserDbContext>();

builder.Services.AddDbContext<UserDbContext>(c =>
c.UseSqlServer(builder.Configuration.GetConnectionString("AppIdentity")));

builder.Services.AddScoped<IPasswordValidator<AppUser>, AppPasswordValidator>();
builder.Services.AddScoped<IUserValidator<AppUser>, AppUserValidator>();

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
