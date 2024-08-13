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

        public AuthBusinessRules(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task UserEmailShouldBeNotExists(string email)
        {
            var userEmail = await _userManager.FindByEmailAsync(email);
            if (userEmail != null)
                throw new BusinessException(AuthMessages.UserMailAlreadyExists);
        }

        public async Task UserRoleShouldExist()
        {
            var roleExists = await _roleManager.RoleExistsAsync("user");
            if (!roleExists)
                throw new BusinessException(AuthMessages.UserRoleDoesNotExist);
        }
    }
}
