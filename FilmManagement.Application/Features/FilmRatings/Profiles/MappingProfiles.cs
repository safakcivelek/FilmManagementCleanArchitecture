using AutoMapper;
using FilmManagement.Application.Features.FilmRatings.Commands.Create;
using FilmManagement.Application.Features.FilmRatings.Dtos;
using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Features.FilmRatings.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // CreateFilmRating
            CreateMap<CreateFilmRatingCommandRequest, FilmRating>().ReverseMap();
            CreateMap<FilmRating, CreateFilmRatingResponseDto>().ReverseMap();
        }
    }
}
