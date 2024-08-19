using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Actors.Queries.GetList
{
    public class GetListActorQueryRequest : IRequest<ApiPagedResponse<GetListActorResponseDto>>
    {
    }
}
