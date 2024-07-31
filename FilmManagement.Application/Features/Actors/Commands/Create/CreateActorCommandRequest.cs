using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Actors.Commands.Create
{
    public class CreateActorCommandRequest : IRequest<ApiResponse<CreateActorResponseDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
