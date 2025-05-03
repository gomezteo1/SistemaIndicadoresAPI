[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var usuario = _userService.ValidarUsuario(request.Email, request.Contrasena);

        if (usuario == null)
        {
            return Unauthorized(new { message = "Credenciales inválidas" });
        }

        // Generar token JWT
        var token = GenerarToken(usuario);

        return Ok(new
        {
            token = token,
            rol = usuario.RolUsuarios.FirstOrDefault()?.FkIdRol, // Asumo que tu usuario tiene rolUsuarios
            nombre = usuario.Nombre,
            email = usuario.Email
        });
    }

    private string GenerarToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
            new Claim("rol", usuario.RolUsuarios.FirstOrDefault()?.FkIdRol ?? "sinrol"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
