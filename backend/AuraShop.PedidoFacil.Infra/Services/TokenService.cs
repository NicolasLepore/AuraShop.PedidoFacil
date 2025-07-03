using AuraShop.PedidoFacil.Infra.Identity.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuraShop.PedidoFacil.Infra.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public string Generate(ApplicationUser user)
        {
            var claims = new Claim[]
            {
                new Claim("Id", user.Id),
                new Claim(ClaimTypes.Name, user.UserName!)
            };

            var key = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_config["Key"]!));

            var credentials = new SigningCredentials
                (key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    claims: claims,
                    signingCredentials: credentials,
                    expires: DateTime.UtcNow.AddHours(12)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
