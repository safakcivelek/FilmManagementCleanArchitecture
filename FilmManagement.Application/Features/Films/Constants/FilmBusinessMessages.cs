namespace FilmManagement.Application.Features.Films.Constants
{
    public static class FilmBusinessMessages
    {
        public const string FilmNameAlreadyExists = "Bu film adı zaten kullanımda. Lütfen başka bir ad seçin.";
        public const string FilmNotFound = "Aramış olduğunuz film veritabanımızda bulunamadı.";
        public const string FilmUpdateFailed = "Film güncellenirken beklenmedik bir sorun oluştu. Lütfen tekrar deneyin."; // boşta
        public const string GenresNotValid = "Seçilen türlerden bazıları sistemimizde tanımlı değil. Lütfen geçerli türler seçin.";
        public const string ActorsNotValid = "Seçilen oyunculardan bir veya daha fazlası kayıtlarımızda bulunamadı. Lütfen oyuncu seçimlerinizi gözden geçirin.";
        public const string DirectorNotValid = "Seçilen yönetmen kayıtlarımızda bulunamadı. Lütfen geçerli bir yönetmen seçin.";
        public const string FilmNotFoundWhenRating = "Derecelendirmek istediğiniz film veritabanımızda bulunamadı.";
    }
}
