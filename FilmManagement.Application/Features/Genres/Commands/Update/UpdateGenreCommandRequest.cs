using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Genres.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Genres.Commands.Update
{
    public class UpdateGenreCommandRequest : IRequest<ApiResponse<UpdateGenreResponseDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
