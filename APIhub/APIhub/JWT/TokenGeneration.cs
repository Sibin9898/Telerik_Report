using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIhub.JWT
{
    public class TokenGeneration
    {
        private readonly IConfiguration _configuration;

        public TokenGeneration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> JWTTokenAsync(string secretKey)
        {
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];

            try
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "User123"),
                    new Claim(ClaimTypes.Role, "Admin"),
                });

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: identity.Claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return tokenString;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
