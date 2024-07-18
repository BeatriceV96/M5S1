using DeliveryService.DataLayer;
using DeliveryService.DataLayer.Interfaces;
using DeliveryService.DataLayer.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using DeliveryService.DataLayer.Services.Models;


var builder = WebApplication.CreateBuilder(args);

// Configura i servizi DAO come scoped
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped< SpedizioneService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Configura il DbContext come scoped
builder.Services.AddScoped<DbContext>();

// Configura i servizi
builder.Services.AddScoped<IAuthService, AuthService>();

// Configura i servizi personalizzati e i controller
builder.Services.AddControllersWithViews();

// Configurazione dell'autenticazione
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Account/Login"; // Pagina di login
    });

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
