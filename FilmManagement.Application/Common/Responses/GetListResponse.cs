namespace FilmManagement.Application.Common.Responses
{
    public class GetListResponse<T>
    {
        private IList<T> _items;

        public IList<T> Items
        {
            get => _items ??= new List<T>();
            set => _items = value;
        }
    }
}
