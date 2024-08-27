using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Genres.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Genres.Commands.Create
{
    public  class CreateGenreCommandRequest : IRequest<ApiResponse<CreateGenreResponseDto>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
