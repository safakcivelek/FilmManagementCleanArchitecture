namespace FilmManagement.Application.Features.Films.Commands.Create
{
    public class CreateFilmCommandResponse
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public Guid DirectorId { get; set; }
    }
}
