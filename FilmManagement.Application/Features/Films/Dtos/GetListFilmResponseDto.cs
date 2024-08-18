using FilmManagement.Application.Features.Actors.Dtos;
using FilmManagement.Application.Features.Directors.Dtos;
using FilmManagement.Application.Features.Genres.Dtos;

namespace FilmManagement.Application.Features.Films.Dtos
{
    public class GetListFilmResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public double Score { get; set; } // Ortalama IMDB Paunı
        public string Image { get; set; }
        public string Video { get; set; }

        public Guid DirectorId { get; set; }

        public ICollection<GetListActorResponseDto> Actors { get; set; }
        public ICollection<GetListGenreResponseDto> Genres { get; set; }
        public GetByIdDirectorResponseDto Director { get; set; }
    }
}
