using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Actors.Queries.GetById
{
    public class GetByIdActorQueryRequest : IRequest<ApiResponse<GetByIdActorResponseDto>>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
