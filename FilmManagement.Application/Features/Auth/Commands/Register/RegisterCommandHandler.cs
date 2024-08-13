using AutoMapper;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.Auth.Dtos;
using FilmManagement.Application.Features.Auth.Rules;
using FilmManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FilmManagement.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, ApiResponse<RegisterResponseDto>>
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(AuthBusinessRules authBusinessRules, IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _authBusinessRules = authBusinessRules;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ApiResponse<RegisterResponseDto>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.Email);
           
            //user rolü her zaman sistemde mevcut olmalı.
            await _authBusinessRules.UserRoleShouldExist();

            User user = _mapper.Map<User>(request);

            IdentityResult result = await _userManager.CreateAsync(user,request.Password);

            if (!result.Succeeded)
                throw new AuthorizationException("Kullanıcı oluşturulamadı: " + string.Join(", ", result.Errors.Select(e => e.Description)));

            await _userManager.AddToRoleAsync(user, "user");

            RegisterResponseDto responseDto = _mapper.Map<RegisterResponseDto>(user);
        
            return new ApiResponse<RegisterResponseDto>(responseDto, "Kullanıcı başarıyla eklendi.");
        }
    }
}
