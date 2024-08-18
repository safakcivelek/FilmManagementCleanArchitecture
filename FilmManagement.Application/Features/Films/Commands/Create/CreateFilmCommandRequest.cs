using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Create
{
    public class CreateFilmCommandRequest : IRequest<ApiResponse<CreateFilmResponseDto>>
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Score { get; set; } 
        public string Image { get; set; }
        public string Video { get; set; }

        public Guid DirectorId { get; set; }

        public ICollection<Guid> ActorIds { get; set; }
        public ICollection<Guid> GenreIds { get; set; }

    }
}
