using Microsoft.IdentityModel.Tokens;
using OrderFlow.API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrderFlow.API.Services.Implementations
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtTokenService(IConfiguration configuration)
        {
            _key = configuration["Jwt:Key"];
            Console.WriteLine($"JWT KEY en JwtTokenService: {_key}");
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
        }
        public string GenerateToken(string email, string userId, string userName, string role) {
            var claims = new List<Claim>
            { 
                new Claim(ClaimTypes.NameIdentifier,userId),
                new Claim (ClaimTypes.Name,userName),
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.Role,role),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credential=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires:DateTime.UtcNow.AddHours(1),
                signingCredentials:credential);
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    } }
