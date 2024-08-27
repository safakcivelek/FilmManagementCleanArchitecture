namespace FilmManagement.Application.Features.Genres.Dtos
{
    public class GetByIdGenreResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
