using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.FilmRatings.Constants;
using FilmManagement.Domain.Entities;
using System.Threading.Tasks;

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

        public async Task<ApiResponse<FilmRating>> AddRatingAsync(FilmRating rating)
        {
            // Ara tabloya, puanlayan kullanıcıyı ve puanını ekle
            FilmRating addedUserRating = await _filmRatingRepository.AddAsync(rating);

            // Filmin ortalama puanını güncelle
            await UpdateFilmRatingAsync(rating.FilmId);

            return new ApiResponse<FilmRating>(addedUserRating, FilmRatingServiceMessages.FilmRatingAddedSuccessfully);
        }


        private async Task UpdateFilmRatingAsync(Guid filmId)
        {
            double UpdatedRating = await CalculateFilmRatingAsync(filmId);

            Film? film = await _filmRepository.GetAsync(f => f.Id == filmId);
            if(film != null)
            {
                film.Score = UpdatedRating;
                await _filmRepository.UpdateAsync(film);
            }
        }

        // Puan ortalamasını hesaplayan metod
        public async Task<double> CalculateFilmRatingAsync(Guid filmId)
        {
            IList<FilmRating> ratingsList = await _filmRatingRepository.GetListAsync(r => r.Id == filmId);
            double UpdatedRating = ratingsList.Average(r => r.Rating);
            return UpdatedRating;
        }     
    }
}
