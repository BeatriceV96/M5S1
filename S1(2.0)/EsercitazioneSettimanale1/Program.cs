using EsercitazioneSettimanale1.DAO;
using EsercitazioneSettimanale1.Models.Services;
using EsercitazioneSettimanale1.Services;
using EsercitazioneSettimanale1.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITrasgressoreDao, TrasgressoreDao>();
builder.Services.AddScoped<IVerbaleDao, VerbaleDao>();
builder.Services.AddScoped<IViolazioneDao, ViolazioneDao>();

builder.Services.AddScoped<TrasgressoreService>();
builder.Services.AddScoped<VerbaleService>();
builder.Services.AddScoped<ViolazioneService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
