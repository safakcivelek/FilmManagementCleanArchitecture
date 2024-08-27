using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Genres.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Genres.Queries.GetList
{
    public class GetListGenreQueryRequest : IRequest<ApiPagedResponse<GetListGenreResponseDto>>
    {
    }
}
