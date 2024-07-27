using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Update
{
    public class UpdateFilmCommandRequest : IRequest<ApiResponse<UpdateFilmResponseDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public Guid DirectorId { get; set; }
    }
}
