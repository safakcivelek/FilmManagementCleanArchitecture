namespace FilmManagement.Domain.Entities
{
    public class Film
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public int DirectorId { get; set; }
        
        public Director Director { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
        public ICollection<FilmActor> FilmActors { get; set; }
        public ICollection<Purchase> Purchases { get; set; } // Burası örnekte yok.
    }
}
