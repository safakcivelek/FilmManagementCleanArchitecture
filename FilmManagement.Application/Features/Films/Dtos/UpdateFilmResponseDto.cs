namespace FilmManagement.Application.Features.Films.Dtos
{
    public class UpdateFilmResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public Guid DirectorId { get; set; }
    }
}
