
namespace FilmManagement.Domain.Entities
{
    public class CustomerFavoriteGenre : BaseEntity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid GenreId { get; set; }

        public Genre Genre { get; set; }
        public Customer Customer { get; set; }
    }
}
