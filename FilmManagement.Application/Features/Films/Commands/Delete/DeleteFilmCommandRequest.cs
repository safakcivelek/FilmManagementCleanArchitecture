using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Delete
{
    public class DeleteFilmCommandRequest : IRequest<ApiResponse<DeleteFilmResponseDto>>
    {
        public Guid Id { get; set; }
    }
}
