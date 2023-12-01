using DataAccess.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authorization;
public static class JwtProvider
{
    public static string CreateToken(User user)
    {
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //Add inside token our roles info
            new Claim(ClaimTypes.Role,"GetAll")
        };
        JwtSecurityToken jwtSecurityToken = new(
            issuer: "Baris Ozgen",
            audience: "www.barisozgen.com",
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretkey1234567890baris")), 
                SecurityAlgorithms.HmacSha256)
            );
        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return token;
    }
}
