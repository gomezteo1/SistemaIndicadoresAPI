using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;


namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;
        private readonly string _jwtKey;
        private readonly string _jwtIssuer;
        private readonly string _jwtAudience;

        public AuthController(SistemaIndicadoresContext context)
        {
            _context = context;
            _jwtKey = "12345678901234567890123456789012"; // Puedes ponerlo en appsettings.json
            _jwtIssuer = "SistemaIndicadoresAPI";
            _jwtAudience = "SistemaIndicadoresAPIUsers";
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Buscar el usuario por email
            var usuario = await _context.Usuario
                .Include(u => u.RolUsuarios)  // Incluir la relación de RolUsuarios
                .FirstOrDefaultAsync(u => u.Email == request.Email);  // Encontrar el usuario por email

            if (usuario == null || usuario.Contrasena != request.Contrasena)
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }

            // Generar el token JWT
            var token = GenerarToken(usuario);

            // Obtener el rol del primer RolUsuario o asignar "sinrol" si no tiene roles
            var rol = usuario.RolUsuarios.FirstOrDefault()?.FkIdRol.ToString() ?? "sinrol";

            return Ok(new
            {
                token = token,
                email = usuario.Email,
                rol = rol
            });
        }

        // Método para generar el JWT
        private string GenerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                new Claim("rol", usuario.RolUsuarios.FirstOrDefault()?.FkIdRol.ToString() ?? "sinrol"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtIssuer,
                audience: _jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // Clase para el body de la petición de login
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }
    }
}
