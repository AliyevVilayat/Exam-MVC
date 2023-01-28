using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectEBusinessMVC.Core.Entities;
using ProjectEBusinessMVC.DataAccess.Contexts;
using ProjectEBusinessMVC.DataAccess.Repositories.Implementations;
using ProjectEBusinessMVC.DataAccess.Repositories.Interfaces;
using ProjectEBusinessMVC.Mapper;

var builder = WebApplication.CreateBuilder(args);
//Services
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(SpecialTeamMapper));

builder.Services.AddScoped<ISpecialTeamRepository, SpecialTeamRepository>();

string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{


}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();
//Http handle request

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
