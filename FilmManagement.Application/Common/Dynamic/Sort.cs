namespace FilmManagement.Application.Common.Dynamic
{
    public class Sort
    {
        public string Field { get; set; }  // Sıralanacak alan
        public string Dir { get; set; }    // Sıralama yönü (asc, desc)

        public Sort()
        {
        }

        public Sort(string field, string dir)
        {
            Field = field;
            Dir = dir;
        }
    }
}
