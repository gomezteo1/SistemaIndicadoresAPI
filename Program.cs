using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 🌐 CORS
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

// 🧩 Inyección de dependencias
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

// 🗃️ DbContext
builder.Services.AddDbContext<SistemaIndicadoresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🚀 Controladores
builder.Services.AddControllers();

// 🔐 Autenticación JWT
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
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:Key"]
                    ?? throw new InvalidOperationException("JWT Key is missing in configuration.")
                )
            )
        };
    });

// 🛠️ Construcción de la app
var app = builder.Build();

app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseAuthentication(); // Siempre antes de Authorization
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "¡Agárrense...! 🚀");

app.Run();
