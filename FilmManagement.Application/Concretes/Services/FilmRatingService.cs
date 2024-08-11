using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Domain.Entities;
using System.Threading.Tasks;

namespace FilmManagement.Application.Concretes.Services
{
    public class FilmRatingService : IFilmRatingService
    {
        private readonly IFilmRatingRepository _filmRatingRepository;
        private readonly IFilmRepository _filmRepository;

        public FilmRatingService(IFilmRatingRepository filmRatingRepository, IFilmRepository filmRepository)
        {
            _filmRatingRepository = filmRatingRepository;
            _filmRepository = filmRepository;
        }

        public async Task<ApiResponse<FilmRating>> AddRatingAsync(FilmRating rating)
        {
            var addedRating = await _filmRatingRepository.AddAsync(rating);
            await UpdateFilmScoreAsync(rating.Id);
            return new ApiResponse<FilmRating>(addedRating, "Puan başarıyla eklend.");
        }

        public async Task<double> CalculateFilmScoreAsync(Guid filmId)
        {
            var ratings = await _filmRatingRepository.GetListAsync(r => r.Id == filmId);
            return ratings.Any() ? ratings.Average(r => r.Rating) : 0.0;
        }

        private async Task UpdateFilmScoreAsync(Guid filmId)
        {
            var score = await CalculateFilmScoreAsync(filmId);
            var film = await _filmRepository.GetAsync(f => f.Id == filmId);
            if (film != null)
            {
                film.Score = score;
                await _filmRepository.UpdateAsync(film);
            }
        }
    }
}
