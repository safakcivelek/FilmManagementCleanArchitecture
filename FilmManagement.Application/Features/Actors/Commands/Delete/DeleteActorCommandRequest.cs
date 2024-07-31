using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Actors.Commands.Delete
{
    public class DeleteActorCommandRequest : IRequest<ApiResponse<DeleteActorResponseDto>>
    {
        public Guid Id { get; set; }     
    }
}
