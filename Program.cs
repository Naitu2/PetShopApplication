using Microsoft.EntityFrameworkCore;
using PetShopApplication.Data;
using PetShopApplication.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepository, PetShopRepository>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<PetShopContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseRouting();
app.UseStaticFiles();

app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
