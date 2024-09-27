using FilmManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FilmManagement.Persistence.SeedData
{
    public class SeedRolesAndUsers
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public SeedRolesAndUsers(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            // Eğer 'user' rolü yoksa ekle
            if (!await _roleManager.RoleExistsAsync("user"))
            {
                await _roleManager.CreateAsync(new Role { Name = "user" });
            }

            // Eğer 'admin' rolü yoksa ekle
            if (!await _roleManager.RoleExistsAsync("admin"))
            {
                await _roleManager.CreateAsync(new Role { Name = "admin" });
            }

            // Eğer admin kullanıcısı yoksa oluştur
            if (await _userManager.FindByEmailAsync("admin@gmail.com") == null)
            {
                var adminUser = new User
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true
                };

                IdentityResult result = await _userManager.CreateAsync(adminUser, "asd123");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "admin");
                }
            }
        }
    }

}
