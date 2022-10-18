using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"])
);



builder.Services
    .AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Account/Login";
//    options.Cookie.Name = "AspNetCore.AppName";
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
//    options.SlidingExpiration = true;
//});

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {

        options.ClientId = "402998534727-1vrh8l1fi11g16qbcqm9j1112io66plg.apps.googleusercontent.com";
        options.ClientSecret = "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";
        options.SignInScheme = IdentityConstants.ExternalScheme;

    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
