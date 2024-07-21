namespace FilmManagement.Domain.Entities
{
    public class FilmGenre : BaseEntity<Guid>
    {
        public Guid GenreId { get; set; }
        public Guid FilmId { get; set; }

        public Genre Genre { get; set; }
        public Film Film { get; set; }
    }
}
