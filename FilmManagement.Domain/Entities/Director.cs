namespace FilmManagement.Domain.Entities
{
    public class Director
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Film> Films { get; set; }
    }
}
