using SistemaIndicadoresAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Cors
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

<<<<<<< HEAD
// 🔹 Inyección de dependencias de repositorios genéricos
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// 🔹 Configuración de la conexión a la base de datos
=======
// Inyección de dependencias
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// DbContext
>>>>>>> f3e8c11abece963b0bd2426c693c5ef2a08b0a8a
builder.Services.AddDbContext<SistemaIndicadoresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

<<<<<<< HEAD
// 🔹 Agregar controladores
builder.Services.AddControllers();

// 🔹 Configurar Autenticación y JWT
=======
// Controllers
builder.Services.AddControllers();

// 🔐 JWT Auth
>>>>>>> f3e8c11abece963b0bd2426c693c5ef2a08b0a8a
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
<<<<<<< HEAD

// 🔹 Construir la aplicación
var app = builder.Build();

// 🔹 Configuración del middleware
app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseAuthentication();  // 👈 Se agrega autenticación antes de autorización
=======
// Build application pipeline
var app = builder.Build();

// Middleware
app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseAuthentication(); // ✅ Importante: va antes que Authorization
>>>>>>> f3e8c11abece963b0bd2426c693c5ef2a08b0a8a
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "¡Agárrense...! 🚀");

app.Run();
