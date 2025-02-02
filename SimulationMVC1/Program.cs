using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimulationMVC1.DAL;
using SimulationMVC1.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<AppUser,IdentityRole>(opt=>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireNonAlphanumeric = false;
    opt.User.RequireUniqueEmail = true;

    opt.Lockout.AllowedForNewUsers = true;
    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);


}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.MapControllerRoute
    (
    "admin",
    "{area:exists}/{controller=home}/{action=index}/{id?}"
    );
app.MapControllerRoute
    (
    "default",
    "{controller=home}/{action=index}/{id?}"
    );  

app.Run();
