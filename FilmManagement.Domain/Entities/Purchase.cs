namespace FilmManagement.Domain.Entities
{
    public class Purchase : BaseEntity<Guid>
    {
        public decimal Price { get; set; }

        public Guid CustomerId { get; set; }
        public Guid FimId { get; set; }

        public Film Film { get; set; }
        public Customer Customer { get; set; }
    }
}
