namespace FilmManagement.Application.Features.Auth.Configurations
{
    public class TokenSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryMinutes { get; set; }
        public int RefreshTokenValidityInDays { get; set; }
    }
}
