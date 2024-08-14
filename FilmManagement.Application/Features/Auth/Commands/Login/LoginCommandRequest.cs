using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Auth.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Auth.Commands.Login
{
    public class LoginCommandRequest : IRequest<ApiResponse<LoginResponseDto>>
    {
        //public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
