using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UsersApplication.Helpers
{
    public static class Authorization
    {
        public static string GenerateJwtToken(string user, string password)
        {
            var claims = new[]
            {
                new Claim("Username", user),
                new Claim("Password", password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("usersapplicationrepo202502102025"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
