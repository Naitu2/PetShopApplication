var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<IRepository, MyRepository>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
//builder.Services.AddDbContext<HrContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    //var ctx = scope.ServiceProvider.GetRequiredService<CityContext>();
    //ctx.Database.EnsureDeleted();
    //ctx.Database.EnsureCreated();
}

app.UseRouting();
app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
