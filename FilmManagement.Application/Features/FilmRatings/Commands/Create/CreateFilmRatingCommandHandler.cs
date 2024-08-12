using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.FilmRatings.Dtos;
using MediatR;
using FilmManagement.Domain.Entities;
using AutoMapper;
using FilmManagement.Application.Features.FilmRatings.Rules;
using FilmManagement.Application.Features.Films.Rules;


namespace FilmManagement.Application.Features.FilmRatings.Commands.Create
{
    public class CreateFilmRatingCommandHandler : IRequestHandler<CreateFilmRatingCommandRequest, ApiResponse<CreateFilmRatingResponseDto>>
    {
        private readonly IFilmRatingService _filmRatingService;
        private readonly FilmRatingBusinessRules _filmRatingBusinessRules;
        private readonly FilmBusinessRules _filmBusinessRules;
        private readonly IMapper _mapper;

        public CreateFilmRatingCommandHandler(IFilmRatingService filmRatingService, FilmRatingBusinessRules filmRatingBusinessRules, IMapper mapper, FilmBusinessRules filmBusinessRules)
        {
            _filmRatingService = filmRatingService;
            _filmRatingBusinessRules = filmRatingBusinessRules;
            _mapper = mapper;
            _filmBusinessRules = filmBusinessRules;
        }

        public async Task<ApiResponse<CreateFilmRatingResponseDto>> Handle(CreateFilmRatingCommandRequest request, CancellationToken cancellationToken)
        {
            // Öncelikle film var mı kontrol edelim
            await _filmBusinessRules.FilmShouldExistWhenRating(request.FilmId);

            // Kullanıcı aynı filmi birden çok derecelendiremez.
            await _filmRatingBusinessRules.UserShouldNotRateSameFilmMultipleTimes(request.UserId, request.FilmId);

            FilmRating filmRating = _mapper.Map<FilmRating>(request);
            // filmRating.CreatedDate = DateTime.Now; //Burayı oto mapliyor mu kontrol edelim!

            ApiResponse<FilmRating> addedRating = await _filmRatingService.AddRatingAsync(filmRating);

            CreateFilmRatingResponseDto responseDto = _mapper.Map<CreateFilmRatingResponseDto>(addedRating.Data);

            return new ApiResponse<CreateFilmRatingResponseDto>(responseDto, addedRating.Message);
        }
    }
}
