using Bakery_API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bakery_API.Services
{
    public class TokenServices
    {
        private readonly AppSettings _appSettings;

        public TokenServices(IOptionsMonitor<AppSettings> optionsMonitor)
        {

            _appSettings = optionsMonitor.CurrentValue;
        }
        public String GenerateToken(User user)
        {

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("Role", user.Role),
                    new Claim ("Name", user.Name),
                    new Claim ("Gender", user.Gender.ToString()),
                    new Claim ("Point", user.Point.ToString()),

                }),
                Expires = DateTime.UtcNow.AddMinutes(1),  // Thời gian hết hạn có thể tùy chỉnh
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKeyBytes),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
