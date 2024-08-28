using Microsoft.AspNetCore.Identity;
using Saic.Models;
using Saic.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServerSideBlazor();

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
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();

app.Run();
