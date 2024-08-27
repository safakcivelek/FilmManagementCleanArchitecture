using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Genres.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Genres.Queries.GetById
{
    public class GetByIdGenreQueryRequest : IRequest<ApiResponse<GetByIdGenreResponseDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
