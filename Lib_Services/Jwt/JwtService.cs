using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JwtService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> CreateJwt(int id_Account, string name_Role)
        {
            string id_AccountString = id_Account.ToString();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("idAccount", id_AccountString),
                        new Claim("typeRole", name_Role!),
                    }),
                Expires = DateTime.UtcNow.AddDays(7), // Thời gian sống của JWT
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return await Task.FromResult(tokenString);
        }

        public async Task<int> GetIdAccount()
        {
            if (!_httpContextAccessor.HttpContext!.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                return 0;
            }
            var tokenHeaders = authorizationHeader!.ToString().Split(' ').Last();
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(tokenHeaders);
            var userIdClaim = token.Claims.FirstOrDefault(claim => claim.Type == "idAccount");
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var idTokenGuidParse))
            {
                return 0;
            }

            return await Task.FromResult(idTokenGuidParse);
        }
    }
}
