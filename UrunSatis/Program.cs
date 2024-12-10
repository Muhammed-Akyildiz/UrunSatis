using Microsoft.EntityFrameworkCore;
using UrunSatis.Data;
using UrunSatis.Services;
using UrunSatis.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Cookie tabanl� oturum a�ma ayarlar�
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";  // Oturum a�ma sayfas�
        options.LogoutPath = "/Account/Logout"; // ��k�� yolu
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturum s�resi
    });

var app = builder.Build();

// Authentication middleware ekleme
app.UseAuthentication();  // Kullan�c� do�rulama
app.UseAuthorization();  // Yetkilendirme

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext to the DI container (SQL Server ba�lant�s�)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services for Dependency Injection (CartService)
builder.Services.AddSingleton<CartService>(); // CartService singleton olarak ekleniyor

// Register repositories for Dependency Injection (e.g. ProductRepository, CategoryRepository)
//builder.Services.AddScoped<IProductRepository, ProductRepository>(); // Scoped olarak ekleniyor
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // Scoped olarak ekleniyor

// Add session support for storing cart items in a session (optional, but useful)
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session zaman a��m�n� 30 dakika olarak ayarlad�k
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // In production, configure exception handling and HSTS
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session usage
app.UseSession();

app.UseAuthorization();

// Map the default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


