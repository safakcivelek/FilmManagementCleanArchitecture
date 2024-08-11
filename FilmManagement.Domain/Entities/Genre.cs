namespace FilmManagement.Domain.Entities
{
    public class Genre : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<FilmGenre>? FilmGenres { get; set; }
    }
}
