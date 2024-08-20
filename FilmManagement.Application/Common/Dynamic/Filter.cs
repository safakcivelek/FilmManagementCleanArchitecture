namespace FilmManagement.Application.Common.Dynamic
{
    public class Filter
    {
        public string Field { get; set; }     // Filtreleme yapılacak alan adı (Genre, Year)
        public string Operator { get; set; }  // Filtreleme operatörü(eq, gt)
        public string? Value { get; set; }    // Filtreleme için kullanılacak değer
        public string? Logic { get; set; }    // Mantıksal operatör (AND, OR). Birden fazla filtrenin nasıl kombinleneceğini belirler.
        public IEnumerable<Filter> Filters { get; set; }  // İç içe filtrelerin listesi. Bir filtre diğer filtreleri içerebilir, böylece                                                          karmaşık filtreleme yapıları oluşturulabilir.

        public Filter()
        {
        }

        public Filter(string field, string @operator, string? value, string? logic, IEnumerable<Filter>? filters) : this()
        {
            Field = field;
            Operator = @operator;
            Value = value;
            Logic = logic;
            Filters = filters;
        }
    }
}
