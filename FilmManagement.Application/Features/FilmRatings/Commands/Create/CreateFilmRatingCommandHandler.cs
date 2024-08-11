using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.FilmRatings.Dtos;
using MediatR;
using FilmManagement.Domain.Entities;
using AutoMapper;


namespace FilmManagement.Application.Features.FilmRatings.Commands.Create
{
    public class CreateFilmRatingCommandHandler : IRequestHandler<CreateFilmRatingCommandRequest, ApiResponse<CreateFilmRatingResponseDto>>
    {
        private readonly IFilmRatingService _filmRatingService;
        //private readonly FilmRatingBusinessRules _filmRatingBusinessRules;
        private readonly IMapper _mapper;

        public CreateFilmRatingCommandHandler(IFilmRatingService filmRatingService, /*FilmRatingBusinessRules filmRatingBusinessRules,*/ IMapper mapper)
        {
            _filmRatingService = filmRatingService;
           // _filmRatingBusinessRules = filmRatingBusinessRules;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CreateFilmRatingResponseDto>> Handle(CreateFilmRatingCommandRequest request, CancellationToken cancellationToken)
        {

            // İş kuralları (Business Rules) kontrol ediliyor
           // await _filmRatingBusinessRules.UserShouldNotRateSameFilmMultipleTimes(request.UserId, request.FilmId);
        
            FilmRating filmRating = _mapper.Map<FilmRating>(request);
            filmRating.CreatedDate = DateTime.Now;
        
            ApiResponse<FilmRating> addedRating = await _filmRatingService.AddRatingAsync(filmRating);
            
            CreateFilmRatingResponseDto responseDto = _mapper.Map<CreateFilmRatingResponseDto>(addedRating.Data);
    
            return new ApiResponse<CreateFilmRatingResponseDto>(responseDto, addedRating.Message);
        }
    }
}
