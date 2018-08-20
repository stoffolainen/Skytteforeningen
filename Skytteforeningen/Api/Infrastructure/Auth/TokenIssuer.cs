using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.User;
using Microsoft.IdentityModel.Tokens;

namespace Api.Infrastructure.Auth
{
    public static class TokenIssuer
    {
        public static TokenResponse AccessToken(User user, TokenIssuerOptions options)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUnixEpochDate().ToString(),
                    ClaimValueTypes.Integer64)
            };

            var jwt = new JwtSecurityToken(
                options.Issuer,
                options.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.Add(options.ValidFor),
                new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.SigningSecret)),
                    SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenResponse(encodedJwt, jwt.ValidTo);
        }
    }
}