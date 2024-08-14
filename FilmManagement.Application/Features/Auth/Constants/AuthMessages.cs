namespace FilmManagement.Application.Features.Auth.Constants
{
    public static class AuthMessages
    {
        public const string UserMailAlreadyExists = "Bu e-posta adresi zaten kayıtlı.";
        public const string UserRoleDoesNotExist = "'user' rolü mevcut değil. Lütfen sistem yöneticisi ile iletişime geçin.";
        public const string EmailOrPasswordInvalid = "Email veya şifre hatalı.";
        public const string UserNotFound = "Kullanıcı bulunamadı.";
        public const string InvalidRefreshToken = "Geçersiz veya süresi dolmuş refresh token.";
    }
}
