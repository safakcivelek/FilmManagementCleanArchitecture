namespace FilmManagement.Domain.Entities
{
    public class Genre
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<FilmGenre> FilmGenres { get; set; }
    }
}
