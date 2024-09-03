using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.FilmRatings.Constants;
using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Concretes.Services
{
    public class FilmRatingService : IFilmRatingService
    {
        private readonly IFilmRatingRepository _filmRatingRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IFilmService _filmService;

        public FilmRatingService(IFilmRatingRepository filmRatingRepository, IFilmRepository filmRepository, IFilmService filmService)
        {
            _filmRatingRepository = filmRatingRepository;
            _filmRepository = filmRepository;
            _filmService = filmService;
        }

        // Puan ekleme ya da güncelleme işlemi yapar
        public async Task<ApiResponse<FilmRating>> AddOrUpdateRatingAsync(FilmRating rating)
        {
            var existingRating = await _filmRatingRepository.GetAsync(fr => fr.UserId == rating.UserId && fr.FilmId == rating.FilmId);

            if (existingRating != null)
            {
                // Eğer kullanıcı daha önce puan vermişse, puanı güncelle
                existingRating.Rating = rating.Rating;
                await _filmRatingRepository.UpdateAsync(existingRating);
            }
            else
                // Eğer kullanıcı daha önce puan vermemişse, yeni puan ekle
                existingRating = await _filmRatingRepository.AddAsync(rating);

            // Filmin ortalama puanını güncelle
            await UpdateFilmAverageRatingAsync(rating.FilmId);

            return new ApiResponse<FilmRating>(existingRating, FilmRatingServiceMessages.FilmRatingAddedSuccessfully);
        }

        // Filmin ortalama puanını günceller
        private async Task UpdateFilmAverageRatingAsync(Guid filmId)
        {
            double UpdatedRating = await CalculateFilmRatingAsync(filmId);

            Film? film = await _filmRepository.GetAsync(f => f.Id == filmId);
            if (film != null)
            {
                film.Score = UpdatedRating;
                await _filmRepository.UpdateAsync(film);
            }
        }

        // Puan ortalamasını hesaplar
        public async Task<double> CalculateFilmRatingAsync(Guid filmId)
        {
            IList<FilmRating> ratingsList = await _filmRatingRepository.GetListAsync(r => r.FilmId == filmId);

            // Eğer rating listesi boşsa 0 döndür
            if (!ratingsList.Any())
                return 0;

            // Ortalama rating'i hesapla ve döndür
            double UpdatedRating = ratingsList.Average(r => r.Rating);
            return UpdatedRating;
        }
    }
}
