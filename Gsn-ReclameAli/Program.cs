using Gsn_ReclameAli.DataContext;
using Gsn_ReclameAli.Interfaces;
using Gsn_ReclameAli.Repository;
using Gsn_ReclameAli.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication("ReclameAliAuth").AddCookie("ReclameAliAuth", options =>
{
    options.Cookie.Name = "ReclameAliAuth";
    options.LoginPath = "/Usuario/Index";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.AccessDeniedPath = "/Usuario/Index";
});

var sql = builder.Configuration.GetConnectionString("conexao");
builder.Services.AddDbContext<GsnReclameAliContext>(o =>
{
    o.UseSqlServer(sql);
    o.EnableSensitiveDataLogging();
});

builder.Services.AddMvcCore();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProblemaRepository, ProblemaRepository>();
builder.Services.AddScoped<IProblemaService, ProblemaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("pt-BR") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
