namespace FilmManagement.Domain.Entities
{
    public class FilmRating : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public double Rating { get; set; } // 0.0 - 10.0 arası puan

        public User User { get; set; }
        public Film Film { get; set; }
    }
}
