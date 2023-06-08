using FarmaFast.Models;
using FarmaFast.Servicios.Contrato;
using FarmaFast.Servicios.Implementacion;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//------------------------------------------------------------------------------------------

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

//configuracion para la cadena de conexion
builder.Services.AddDbContext<FarmaFastContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("QuerySql")));

builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddRazorPages()
.AddMvcOptions(options =>
{
    options.MaxModelValidationErrors = 50;
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
    _ => "Este campo es requerido");
});

//------------------------------------------------------------------------------------------

builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie(option =>
       {
           option.LoginPath = "/Login/Index";
           option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
       });

//------------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
