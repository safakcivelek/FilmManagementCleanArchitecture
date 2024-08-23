using FilmManagement.Application.Common.Dynamic;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Films.Queries.GetList
{
    public class GetListFilmQueryRequest :IRequest<ApiPagedResponse<GetListFilmResponseDto>>
    {
        public int? Start { get; set; } = 0; // Başlangıç indeksi
        public int? Limit { get; set; } = 10; // Kaç film çekileceği
        public DynamicQuery? DynamicQuery { get; set; }
    }
}
