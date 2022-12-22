using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TwitterClone.Business.Extension;
using TwitterClone.Business.IServices;
using TwitterClone.Business.Models;

namespace TwitterClone.Server.Services
{
    public class TokenService : ITokenService
    {
        public string BuildToken(string key, UserModel user)
        {
            var claims = new[] {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
             };

            if (user.IsAdmin)
                claims.Append(new Claim(ClaimTypes.Role, "Admin"));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(claims: claims,
                expires: DateTime.Now.AddDays(30), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }

        public bool ComparePasswords(string inputPassword, string hashedPassword, string salt)
        {
            var a = (inputPassword + salt).CreateMD5();
            return (inputPassword + salt).CreateMD5() == hashedPassword;
        }

        public bool ValidateUser(UserModel user)
        {
            if (user == null)
                return false;
            if (string.IsNullOrEmpty(user.Email))
                return false;
            if (string.IsNullOrEmpty(user.Password))
                return false;
            if (string.IsNullOrEmpty(user.UserName))
                return false;

            return true;
        }

    }
}
