using Microsoft.IdentityModel.Tokens;
using MyWebApi.Core.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyWebApi.Business;

public class JwtToken()
{
    public string GenerateToken(UserDto user)
    {
        Claim[] claims = [new("userId", user.Id.ToString())];

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyWebApiSecretKeyMyWebApiSecretKeyMyWebApiSecretKey"));

        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: "ProjectMyWebApi",
            audience: "UI",
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signinCredentials);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return tokenString;
    }
}
