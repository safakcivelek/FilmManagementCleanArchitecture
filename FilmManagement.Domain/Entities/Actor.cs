namespace FilmManagement.Domain.Entities
{
    public class Actor : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<FilmActor> FilmActors { get; set; }
    }
}
