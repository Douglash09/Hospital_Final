using Microsoft.EntityFrameworkCore;
using Hospital_Final.Data;
using Hospital_Final.Data;

var builder = WebApplication.CreateBuilder(args);

// Conexión a MySQL con Entity Framework Core
builder.Services.AddDbContext<HospitalContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36)) // Ajusta si usas otra versión de MySQL
    ));

// Habilita controladores con vistas (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Define la ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
