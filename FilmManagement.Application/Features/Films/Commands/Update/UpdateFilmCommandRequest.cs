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
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Score { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }

        public Guid DirectorId { get; set; }

        public ICollection<Guid> GenreIds { get; set; }
        public ICollection<Guid> ActorIds { get; set; }
    }
}
