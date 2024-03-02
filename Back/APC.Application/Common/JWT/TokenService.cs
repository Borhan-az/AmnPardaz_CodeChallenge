using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace APC.Application.Common.JWT
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> GenerateToken(Guid userId, string userName)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["secretkey"]));
            var tokenHandler = new JwtSecurityTokenHandler();
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>()
            {
                new Claim("username",userName),
                new Claim(ClaimTypes.NameIdentifier,userId.ToString()),
            };

            if (userName.Trim().ToLower().Equals("admin"))
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            else
                claims.Add(new Claim(ClaimTypes.Role, "user"));
            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _configuration["Issuer"],
                Audience = _configuration["Audience"],
                Expires = DateTime.Now.AddMinutes(120),
                SigningCredentials = creds
            };
            var newAccessToken = tokenHandler.CreateToken(tokenDes);
            var encodedAccessToken = tokenHandler.WriteToken(newAccessToken);
            return Task.FromResult(encodedAccessToken);

        }
    }
}