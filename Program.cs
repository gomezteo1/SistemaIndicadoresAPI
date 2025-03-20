using SistemaIndicadoresAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//permi api
var corsPolicy = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Agregar esto antes de "app.UseAuthorization();"
// Configurar la conexión a la base de datos
builder.Services.AddDbContext<SistemaIndicadoresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Agregar controladores y servicios
builder.Services.AddControllers();

var app = builder.Build();
app.UseCors(corsPolicy);
// Configurar Middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "¡Agarranse...! 🚀");
app.Run();
