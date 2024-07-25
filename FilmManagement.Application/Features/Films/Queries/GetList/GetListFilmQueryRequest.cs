using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Films.Queries.GetList
{
    public class GetListFilmQueryRequest :IRequest<GetListResponse<GetListFilmDto>>
    {
    }
}
