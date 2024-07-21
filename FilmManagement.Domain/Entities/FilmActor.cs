namespace FilmManagement.Domain.Entities
{
    public class FilmActor : BaseEntity<Guid>
    {
        public Guid FilmId { get; set; }
        public Guid ActorId { get; set; }

        public Film Film { get; set; }
        public Actor Actor { get; set; }
    }
}
