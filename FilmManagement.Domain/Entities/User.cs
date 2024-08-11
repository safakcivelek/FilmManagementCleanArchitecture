using Microsoft.AspNetCore.Identity;

namespace FilmManagement.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<FilmRating> FilmRatings { get; set; } 
    }
}
