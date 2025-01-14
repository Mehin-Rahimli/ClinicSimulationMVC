using Microsoft.EntityFrameworkCore;
using SimulationMVC1.DAL;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();




app.UseStaticFiles();
app.MapControllerRoute
    (
    "default",
    "{controller=about}/{action=index}/{id?}"
    );  

app.Run();
