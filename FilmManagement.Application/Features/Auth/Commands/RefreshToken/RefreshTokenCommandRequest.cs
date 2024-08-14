using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Auth.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandRequest : IRequest<ApiResponse<RefreshTokenResponseDto>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
