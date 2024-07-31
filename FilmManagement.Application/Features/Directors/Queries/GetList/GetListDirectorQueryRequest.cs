using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Directors.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Directors.Queries.GetList
{
    public class GetListDirectorQueryRequest : IRequest<ApiListResponse<GetListDirectorResponseDto>>
    {
       
    }
}
