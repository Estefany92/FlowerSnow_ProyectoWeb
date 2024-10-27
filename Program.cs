using FlowerSnow_ProyectoWeb.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Servicios al contenedor de inyeccion de dependendecias añadimos autenticacion y otros sobre usuarios
//Este nos permitira que uno de los roles sea administrador para acceder a ciertas areas de la app restrigciones
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
        "RequireAdminOrStaff", //Nombre de la politica
        policy => policy.RequireRole("Administrador", "Staff")
        );
});


//autenticacion con cookies tiempo expiracion y acceso denegado
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //TIEMPO DE INACTIVIDAD PARA QUE SE CIERRE AL SESIO
    options.LoginPath = ""; //ruta de inicio de sesion y de acceso denegado es parecido a poner en el buscador/home o /burguer llamar a las vistas y controladores pero estya vez se crean en otro lado
    options.AccessDeniedPath = "";
});

//configurar servicios a utilizar






//Creacion de DBsETS PARA TABLAS <archivo> 
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

//paso para que primero se autentique y luego autorice
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
