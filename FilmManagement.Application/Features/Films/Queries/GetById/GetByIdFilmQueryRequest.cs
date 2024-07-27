using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Films.Queries.GetById
{
    public class GetByIdFilmQueryRequest : IRequest<ApiResponse<GetByIdFilmResponseDto>>
    {
        public Guid Id { get; set; }
    }
}
