using productCatalogMVC.Repositories.Interfaces;
using productCatalogMVC.Repositories.Implementations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductRepository>(sp =>
{
    var cfg = sp.GetRequiredService<IConfiguration>();
    return new ProductRepository(cfg.GetConnectionString("MySqlConnection"));
});

builder.Services.AddScoped<ICartRepository>(sp =>
{
    var cfg = sp.GetRequiredService<IConfiguration>();
    return new CartRepository(cfg.GetConnectionString("MySqlConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");


app.Run();
