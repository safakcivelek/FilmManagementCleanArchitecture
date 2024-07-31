using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Directors.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Directors.Commands.Create
{
    public class CreateDirectorCommandRequest : IRequest<ApiResponse<CreateDirectorResponseDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
