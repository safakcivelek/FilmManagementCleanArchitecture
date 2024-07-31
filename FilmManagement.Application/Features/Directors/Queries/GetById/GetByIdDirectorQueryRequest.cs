using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Directors.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Directors.Queries.GetById
{
    public class GetByIdDirectorQueryRequest : IRequest<ApiResponse<GetByIdDirectorResponseDto>>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
