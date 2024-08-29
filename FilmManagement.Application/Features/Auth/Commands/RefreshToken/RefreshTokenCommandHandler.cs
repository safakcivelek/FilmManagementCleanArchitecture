using FilmManagement.Application.Abstracts.Tokens;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.Auth.Configurations;
using FilmManagement.Application.Features.Auth.Dtos;
using FilmManagement.Application.Features.Auth.Rules;
using FilmManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace FilmManagement.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, ApiResponse<RefreshTokenResponseDto>>
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly TokenSettings _tokenSettings;

        public RefreshTokenCommandHandler(ITokenService tokenService, UserManager<User> userManager, AuthBusinessRules authBusinessRules, IOptions<TokenSettings> tokenSettings)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _authBusinessRules = authBusinessRules;
            _tokenSettings = tokenSettings.Value;
        }

        public async Task<ApiResponse<RefreshTokenResponseDto>> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Expired token'dan kullanıcıyı bul
                ClaimsPrincipal principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
                string? email = principal.FindFirstValue(ClaimTypes.Email);

                // Kullanıcıyı iş kuralı aracılığıyla bul
                User user = await _authBusinessRules.UserShouldExist(email);

                // Refresh token'ı doğrula
                await _authBusinessRules.RefreshTokenShouldBeValid(user, request.RefreshToken);

                // Yeni Access ve Refresh Token oluştur
                string newAccessToken = await _tokenService.GenerateAccessTokenAsync(user);
                string newRefreshToken = await _tokenService.GenerateRefreshTokenAsync(user);

                // Yeni Refresh Token'ı kullanıcıya kaydet
                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(_tokenSettings.RefreshTokenValidityInDays);

                IdentityResult result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    //Güncelleme sırasında hata durumuna karşı önlem alınmalı.
                    //Transaction, UnitOfWork, vb....
                }

                // Yeni Access Token'ın süresini hesapla ve döndür
                DateTime expiration = DateTime.Now.AddMinutes(_tokenSettings.ExpiryMinutes);
                var response = new RefreshTokenResponseDto
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken,
                    Expiration = expiration
                };

                return new ApiResponse<RefreshTokenResponseDto>(response, "Token başarıyla yenilendi.");
            }
            catch (AuthorizationException ex)
            {
                // Eğer Refresh Token geçersizse veya süresi dolmuşsa 401 Unauthorized döneriz
                return new ApiResponse<RefreshTokenResponseDto>(null, ex.Message,401);
            }          
        }
    }
}
