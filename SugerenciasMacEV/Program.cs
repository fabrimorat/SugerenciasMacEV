using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SugerenciasMacEV.Data;
using SugerenciasMacEV.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de los servicios
builder.Services.AddScoped<ISugerenciaService, SugerenciaService>();
builder.Services.AddAuthorization();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true; // Opcional: Indenta el JSON para una mejor legibilidad
});
builder.Services.AddControllersWithViews()
    .AddSessionStateTempDataProvider();

// Configuraci�n de la cadena de conexi�n
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configuraci�n del DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configuraci�n del pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
