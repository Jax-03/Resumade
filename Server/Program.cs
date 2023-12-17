using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Resumade.Api;
using Resumade.Server.Data;
using Resumade.Server.DataAccess;
using Resumade.Server.DataAccess.Interfaces;
using Resumade.Server.Models;
using Resumade.Server.Services;
using Resumade.Server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var authConnectionString = builder.Configuration.GetConnectionString("AuthConnectionString") ?? throw new InvalidOperationException("Connection string 'AuthConnectionString' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(authConnectionString));

var resumadeConnection = builder.Configuration.GetConnectionString("ResumadeConnection") ?? throw new InvalidOperationException("Connection string 'ResumadeConnection' not found.");
builder.Services.AddDbContext<ResumadeContext>(options => options.UseSqlServer(resumadeConnection));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IDropdownListService, DropdownListService>();
builder.Services.AddScoped<INavigationMenuService, NavigationMenuService>();
builder.Services.AddScoped<IResumadeDataAccess, ResumadeDataAccess>();
builder.Services.AddScoped<IDropDownListDataAccess, DropDownListDataAccess>();
builder.Services.AddScoped<INavigationMenuDataAccess, NavigationMenuDataAccess>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseBlazorFrameworkFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(app.Environment.ContentRootPath, "Media")),
    RequestPath = "/Media"
});

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
