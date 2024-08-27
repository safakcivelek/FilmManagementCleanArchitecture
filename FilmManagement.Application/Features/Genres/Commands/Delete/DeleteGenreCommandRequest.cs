using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Genres.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Genres.Commands.Delete
{
    public class DeleteGenreCommandRequest : IRequest<ApiResponse<DeleteGenreResponseDto>>
    {
        public Guid Id { get; set; }
    }
}
