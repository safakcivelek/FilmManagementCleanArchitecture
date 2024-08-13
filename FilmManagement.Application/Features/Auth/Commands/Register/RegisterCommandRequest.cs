using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Auth.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandRequest : IRequest<ApiResponse<RegisterResponseDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
