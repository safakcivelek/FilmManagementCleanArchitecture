using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.Auth.Constants;
using FilmManagement.Application.Rules;
using FilmManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FilmManagement.Application.Features.Auth.Rules
{
    public class AuthBusinessRules : BaseBusinessRules
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public AuthBusinessRules(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task UserEmailShouldBeNotExists(string email)
        {
            User? userEmail = await _userManager.FindByEmailAsync(email);
            if (userEmail != null)
                throw new BusinessException(AuthMessages.UserMailAlreadyExists);
        }

        public async Task UserRoleShouldExist()
        {
            bool doesExist = await _roleManager.RoleExistsAsync("user");
            if (!doesExist)
                throw new BusinessException(AuthMessages.UserRoleDoesNotExist);
        }

        public async Task EmailOrPasswordShouldBeValid(User user,string password)
        {
            bool doesExist = await _userManager.CheckPasswordAsync(user, password);
            if (!doesExist)
                throw new AuthorizationException(AuthMessages.EmailOrPasswordInvalid);
        }

        public async Task<User> UserShouldExist(string email)
        {
            User? user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new AuthorizationException(AuthMessages.UserNotFound);
            return user;
        }

        public async Task UserShouldBeAbleToSignIn(User user,string password)
        {
            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (!signInResult.Succeeded)
                throw new AuthorizationException(AuthMessages.EmailOrPasswordInvalid);
        }

        public async Task<ApiResponse<bool>> RefreshTokenShouldBeValid(User user,string refreshToken)
        {
            if (user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)        
                return new ApiResponse<bool>(false, AuthMessages.InvalidRefreshToken, 401);
            return new ApiResponse<bool>(true, "Refresh token geçerli");
        }
    }
}
