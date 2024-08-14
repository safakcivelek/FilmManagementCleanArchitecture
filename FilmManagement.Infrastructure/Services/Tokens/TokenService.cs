using FilmManagement.Application.Abstracts.Tokens;
using FilmManagement.Application.Features.Auth.Configurations;
using FilmManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FilmManagement.Infrastructure.Services.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenSettings _tokenSettings;

        public TokenService(UserManager<User> userManager, IOptions<TokenSettings> options)
        {
            _userManager = userManager;
            _tokenSettings = options.Value;
        }

        public async Task<string> GenerateAccessTokenAsync(User user)
        {
            List<Claim> authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
                authClaims.Add(new Claim(ClaimTypes.Role, role));

            SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: DateTime.Now.AddMinutes(_tokenSettings.ExpiryMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );


            #region AddClaimsAsync() bilgi
            //AddClaimsAsync() : Her kullanıcı rolünü veritabanında saklar. Veritabanına ek yük getirebilir.
            //Eğer bu satırı eklemez isek, claim'ler sadece JWT token içinde geçici olarak saklanır ve kullanıcıya ait claim'ler veritabanına kaydedilmez. Bu durumda, her JWT token oluşturma işleminde claim'lerin tekrar oluşturulması gerekir. 
            #endregion
            await _userManager.AddClaimsAsync(user, authClaims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GenerateRefreshTokenAsync(User user)
        {
            var randomNumber = new byte[64];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);         
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false, //refresh token kullanılması durumunda 'false' uygundur.
                ValidateIssuerSigningKey = true,
                ValidIssuer = _tokenSettings.Issuer,
                ValidAudience = _tokenSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret)),
                ClockSkew = TimeSpan.Zero
            };

            JwtSecurityTokenHandler tokenHandler = new();
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken
                              || !jwtSecurityToken.Header.Alg
                              .Equals(SecurityAlgorithms.HmacSha256,
                              StringComparison.InvariantCultureIgnoreCase)
                              )
                throw new SecurityTokenException("Token bulunamadı.");

            return principal;
        }
    }
}

