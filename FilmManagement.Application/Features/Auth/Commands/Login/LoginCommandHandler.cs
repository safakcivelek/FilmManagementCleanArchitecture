using FilmManagement.Application.Abstracts.Tokens;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Auth.Dtos;
using FilmManagement.Application.Features.Auth.Rules;
using FilmManagement.Domain.Entities;
using FilmManagement.Application.Features.Auth.Configurations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace FilmManagement.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, ApiResponse<LoginResponseDto>>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly TokenSettings _tokenSettings;
        
        public LoginCommandHandler(UserManager<User> userManager, ITokenService tokenService, AuthBusinessRules authBusinessRules, IOptions<TokenSettings> tokenSettings )
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _authBusinessRules = authBusinessRules;
            _tokenSettings = tokenSettings.Value;
        }
        public async Task<ApiResponse<LoginResponseDto>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            // Kullanıcı kontrolü yap
            await _authBusinessRules.UserShouldExist(request.Email);

            User? user = await _userManager.FindByEmailAsync(request.Email);
            await _authBusinessRules.EmailOrPasswordShouldBeValid(user, request.Password);

            // Access ve Refresh Token oluştur
            string accessToken = await _tokenService.GenerateAccessTokenAsync(user);
            string refreshToken = await _tokenService.GenerateRefreshTokenAsync(user);
           
            // Refresh Token'ı veritabanına kaydet
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(_tokenSettings.RefreshTokenValidityInDays);
            IdentityResult result =await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {             
                //Güncelleme sırasında hata durumuna karşı önlem alınmalı.
                //Transaction, UnitOfWork, vb....
            }        

            await _userManager.UpdateSecurityStampAsync(user);
               
            // Access Token'ın süresini hesapla ve döndür
            DateTime expiration = DateTime.Now.AddMinutes(_tokenSettings.ExpiryMinutes);
            return new ApiResponse<LoginResponseDto>(new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Expiration = expiration
            }, "Kullanıcı başarıyla giriş yaptı.");
        }
    }
}
