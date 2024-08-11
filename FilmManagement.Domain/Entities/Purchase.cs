namespace FilmManagement.Domain.Entities
{
    public class Purchase : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid FimId { get; set; }

        public decimal Price { get; set; }      

        public Film Film { get; set; }
        public User User { get; set; }       
    }
}
