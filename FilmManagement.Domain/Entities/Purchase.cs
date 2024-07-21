namespace FilmManagement.Domain.Entities
{
    public class Purchase
    {
        public decimal Price { get; set; }

        public int CustomerId { get; set; }
        public int FimId { get; set; }

        public Film Film { get; set; }
        public Customer Customer { get; set; }
    }
}
