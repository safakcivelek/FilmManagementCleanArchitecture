namespace FilmManagement.Domain.Entities
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
