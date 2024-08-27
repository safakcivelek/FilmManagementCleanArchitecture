namespace FilmManagement.Application.Features.Genres.Dtos
{
    public class UpdateGenreResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
