using SistemaIndicadoresAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configuración CORS
var corsPolicy = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy, policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 🔹 Inyección de dependencias de repositorios genéricos
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// 🔹 Configuración de la conexión a la base de datos
builder.Services.AddDbContext<SistemaIndicadoresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🔹 Agregar controladores
builder.Services.AddControllers();

// 🔹 Configurar Autenticación y JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// 🔹 Construir la aplicación
var app = builder.Build();

// 🔹 Configuración del middleware
app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseAuthentication();  // 👈 Se agrega autenticación antes de autorización
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "¡Agárrense...! 🚀");

app.Run();
