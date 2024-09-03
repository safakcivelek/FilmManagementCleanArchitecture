using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.FilmRatings.Constants;
using FilmManagement.Application.Rules;

namespace FilmManagement.Application.Features.FilmRatings.Rules
{
    public class FilmRatingBusinessRules : BaseBusinessRules
    {
        private readonly IFilmRatingRepository _filmRatingRepository;

        public FilmRatingBusinessRules(IFilmRatingRepository filmRatingRepository)
        {
            _filmRatingRepository = filmRatingRepository;
        }      
    }
}
