using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationService.API.Controllers;

/// <summary> Syed Shujaat Ali
/// API controller for authentication and JWT token generation.
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    /// <summary> Syed Shujaat Ali
    /// Initializes a new instance of the <see cref="AuthController"/> class.
    /// </summary>
    /// <param name="configuration">The application configuration instance.</param>
    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary> Syed Shujaat Ali
    /// Authenticates a user and returns a JWT token if credentials are valid.
    /// </summary>
    /// <param name="request">The login request containing username and password.</param>
    /// <returns>An Ok result with the JWT token if successful; otherwise, Unauthorized.</returns>
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Read credentials from appsettings.json
        var validUsername = _configuration["Auth:Username"];
        var validPassword = _configuration["Auth:Password"];

        if (request.Username == validUsername && request.Password == validPassword)
        {
            var token = GenerateJwtToken(request.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized("Invalid credentials");
    }

    /// <summary> Syed Shujaat Ali
    /// Generates a JWT token for the specified username.
    /// </summary>
    /// <param name="username">The username for which to generate the token.</param>
    /// <returns>A JWT token string.</returns>
    private string GenerateJwtToken(string username)
    {
        var secretKey = _configuration["Jwt:Key"];
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
