using Microsoft.EntityFrameworkCore;
using PetShopApplication.Data;
using PetShopApplication.Repositories;
using PetShopApplication.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPetShopRepository, PetShopRepository>();
builder.Services.AddSingleton<IListViewModelService, ListViewModelService>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<PetShopContext>(options => options.UseSqlServer(connectionString));

/*builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
*/
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();

    var environment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
    FileService.ManageAnimalImages(environment);
}

/*app.UseSession();*/

app.UseRouting();
app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
