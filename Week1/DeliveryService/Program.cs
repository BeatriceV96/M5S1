using DeliveryService.DataLayer.Interfaces;
using DeliveryService.DataLayer.Services;
using DeliveryService.DataLayer.Services.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurazione dell'autenticazione
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });


// Fine configurazione dell'autenticazione

// Configurazione del servizio di gestione delle autenticazioni
builder.Services.AddScoped<IAuthService, AuthService>(); // Assicurati che l'interfaccia e il servizio siano corretti

// Aggiungi qui la registrazione di SpedizioneService
builder.Services.AddScoped<SpedizioneService>();
// Sostituisci ISpedizioneService con l'interfaccia corretta se esiste

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
