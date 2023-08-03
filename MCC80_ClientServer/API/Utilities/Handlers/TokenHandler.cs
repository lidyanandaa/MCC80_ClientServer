using API.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Utilities.Handlers
{
    public class TokenHandler : ITokenHandler
    { 
        public readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? GenerateToken(IEnumerable<Claim> claims)
        {
            //secretkey akan diubah menjadi bit/byte  
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8
                                                             .GetBytes(_configuration["JWTConfig:SecretKey"]));

            //akan dienskripsi lagi dalam bentuk HMACA256 untuk mengenskripsi secretkey
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            //setting token
            var tokenOptions = new JwtSecurityToken(issuer: _configuration["JWTConfig:Issuer"],
                                                    audience: _configuration["JWTConfig:Audience"],
                                                    claims: claims,
                                                    //diberikan expired date
                                                    expires: DateTime.Now.AddMinutes(10),
                                                    signingCredentials: signinCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
