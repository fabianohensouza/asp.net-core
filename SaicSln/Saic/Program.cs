using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Saic.Models;
using Saic.Models.Repositories;
using Saic.Models.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<StoreDbContext>(opts => {
    opts.UseSqlServer(
    builder.Configuration["ConnectionStrings:SaicConnection"]);
});

builder.Services.AddScoped<ICoopRepository, EFCoopRepository>();
builder.Services.AddScoped<IRespRepository, EFRespRepository>();
builder.Services.AddScoped<IUnidadeRepository, EFUnidadeRepository>();

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/error");
}

app.UseRequestLocalization(opts => {
    opts.AddSupportedCultures("pt-BR")
    .AddSupportedUICultures("pt-BR")
    .SetDefaultCulture("pt-BR");
});

app.UseStaticFiles();

//app.MapControllerRoute("coopSelecionada", "{coopSelecionada}",
//    new { Controller = "Home", action = "Index", coopPage = 1 });

app.MapControllerRoute("pagination", "Coops/Page{coopPage}",
    new { Controller = "Home", action = "Index" });

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();

SeedCoop.EnsurePopulated(app);

app.Run();
