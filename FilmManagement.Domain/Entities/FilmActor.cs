namespace FilmManagement.Domain.Entities
{
    public class FilmActor
    {
        public int FilmId { get; set; }
        public int ActorId { get; set; }

        public Film Film { get; set; }
        public Actor Actor { get; set; }
    }
}
