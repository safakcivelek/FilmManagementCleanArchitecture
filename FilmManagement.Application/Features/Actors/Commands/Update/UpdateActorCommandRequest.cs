using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Actors.Commands.Update
{
    public class UpdateActorCommandRequest : IRequest<ApiResponse<UpdateActorResponseDto>>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
