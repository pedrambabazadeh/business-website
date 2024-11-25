using API.Models;
using API.MicroServices.Users.Src.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API.MicroServices.Users.Src.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration config;
        private readonly SymmetricSecurityKey key;

        public TokenService(IConfiguration config)
        {
            this.config = config;
            key = new (Encoding.UTF8.GetBytes(config["JWT:SigninKey"]));
        }

        public string Create(AppUser appUser)
        {
            var claims = new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Email, appUser.Email),
                            new Claim(JwtRegisteredClaimNames.GivenName, appUser.UserName)
                        };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new SecurityTokenDescriptor
                                    {
                                        Subject = new ClaimsIdentity(claims),
                                        Expires = DateTime.Now.AddDays(7),
                                        SigningCredentials = creds,
                                        Issuer = config["JWT:Issuer"],
                                        Audience = config["JWT:Audience"]
                                    };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}