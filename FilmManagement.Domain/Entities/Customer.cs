namespace FilmManagement.Domain.Entities
{
    public class Customer: BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<CustomerFavoriteGenre> CustomerFavoriteGenres { get; set; }
    }
}
