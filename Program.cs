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

// Inyección de dependencias
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// DbContext
builder.Services.AddDbContext<SistemaIndicadoresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Controllers
builder.Services.AddControllers();

// 🔐 JWT Auth
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
// Build application pipeline
var app = builder.Build();

// Middleware
app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseAuthentication(); // ✅ Importante: va antes que Authorization
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "¡Agárrense...! 🚀");

app.Run();
