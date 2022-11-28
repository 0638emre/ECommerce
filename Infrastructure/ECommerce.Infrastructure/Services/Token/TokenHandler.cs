using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using ECommerce.Application.Abstraction.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        //Bu servis handler ile API deki program cs dosyası içerisindeki istenilen token configurasyonunu oluşturuyoruz.
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int minute)
        {

            Application.DTOs.Token token = new();

            //Securuty Key'in simetriğini alıyoruz 
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //oluşturulacak token ayarlarını veriyoruz
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow, //ne zaman devreye girsin üretildiği an girsin.
                signingCredentials: signingCredentials
                );

            //token oluşturucu sınıfından örnek alalım.
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
