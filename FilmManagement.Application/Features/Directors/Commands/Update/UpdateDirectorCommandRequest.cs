using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Directors.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Directors.Commands.Update
{
    public class UpdateDirectorCommandRequest : IRequest<ApiResponse<UpdateDirectorResponseDto>>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
