namespace FilmManagement.Application.Features.FilmRatings.Dtos
{
    public class CreateFilmRatingResponseDto 
    {
        public Guid UserId { get; set; }
        public Guid FilmId { get; set; }
        public int Rating { get; set; }
    }
}
