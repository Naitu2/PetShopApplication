using Microsoft.EntityFrameworkCore;
using PetShopApplication.Data;
using PetShopApplication.Repositories;
using PetShopApplication.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPetShopRepository, PetShopRepository>();
builder.Services.AddSingleton<IListViewModelService, ListViewModelService>();
string petShopconnectionString = builder.Configuration["ConnectionStrings:PetShopConnection"]!;
builder.Services.AddDbContext<PetShopContext>(options => options.UseSqlServer(petShopconnectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();

    var environment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
    FileService.ManageAnimalImages(environment);
}

if (app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error/Index");
}


app.UseRouting();
app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
