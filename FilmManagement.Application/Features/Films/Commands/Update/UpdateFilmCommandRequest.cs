using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Update
{
    public class UpdateFilmCommandRequest : IRequest<UpdateFilmCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public Guid DirectorId { get; set; }
    }
}
