using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Directors.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Directors.Commands.Delete
{
    public class DeleteDirectorCommandRequest : IRequest<ApiResponse<DeleteDirectorResponseDto>>
    {
        public Guid Id { get; set; }
    }
}
