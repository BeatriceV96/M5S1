using DeliveryService.DataLayer;
using DeliveryService.DataLayer.Interfaces;
using DeliveryService.DataLayer.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using DeliveryService.DataLayer.Services.Models;



var builder = WebApplication.CreateBuilder(args);

// Configura i servizi per l'applicazione
builder.Services.AddControllersWithViews();

// Configurazione del DbContext
//builder.Services.AddDbContext<DbContext>(options =>
   // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurazione dell'autenticazione
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Account/Login"; // Pagina di login
    });

// Configurazione dei servizi di autenticazione e spedizione
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<DbContext>();


var app = builder.Build();

// Configura la pipeline delle richieste HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Configurazione delle rotte dei controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
