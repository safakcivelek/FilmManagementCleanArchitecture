using FilmManagement.Domain.Entities;
using System.Security.Claims;

namespace FilmManagement.Application.Abstracts.Tokens
{
    public interface ITokenService
    {
        Task<string> GenerateAccessTokenAsync(User user);
        Task<string> GenerateRefreshTokenAsync(User user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
