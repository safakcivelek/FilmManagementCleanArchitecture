namespace FilmManagement.Domain.Entities
{
    public class FilmGenre
    {
        public int GenreId { get; set; }
        public int FilmId { get; set; }

        public Genre Genre { get; set; }
        public Film Film { get; set; }
    }
}
