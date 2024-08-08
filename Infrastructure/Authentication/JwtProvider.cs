using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.User.Entities;
using Infrastructure.Authentication.Config;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtProperties _properties;
    private readonly JwtSecurityTokenHandler _jwtHandler;

    public JwtProvider(JwtProperties properties)
    {
        this._properties = properties;
        _jwtHandler = new JwtSecurityTokenHandler();
    }

    public string Generate(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_properties.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)).ToList();
        userClaims.Add(new Claim(ClaimTypes.Email, user.Email));
        userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

        var token = new JwtSecurityToken(
                issuer: _properties.Issuer,
                audience: _properties.Audience,
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(_properties.Expiry),
                signingCredentials: credentials
            );

        return _jwtHandler.WriteToken(token);
    }
}