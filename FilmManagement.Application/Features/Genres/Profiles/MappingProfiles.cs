using AutoMapper;
using FilmManagement.Application.Features.Genres.Dtos;
using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Features.Genres.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Genre, GetListGenreResponseDto>().ReverseMap();
        }
    }
}
