using AutoMapper;
using FilmManagement.Application.Features.Films.Commands.Create;
using FilmManagement.Application.Features.Films.Commands.Delete;
using FilmManagement.Application.Features.Films.Commands.Update;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Features.Films.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //GetList
            CreateMap<Film, GetListFilmResponseDto>()
                  .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.FilmActors
                  .Select(fa => fa.Actor)))
                  .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.FilmGenres
                  .Select(fg => fg.Genre))).ReverseMap();

            //GetById
            CreateMap<Film, GetByIdFilmResponseDto>()
                  .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.FilmActors
                  .Select(fa => fa.Actor)))
                  .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.FilmGenres
                  .Select(fg => fg.Genre))).ReverseMap();

            //Add
            CreateMap<CreateFilmCommandRequest, Film>()
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score ?? 0))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.Image) ? null : src.Image)) 
                .ForMember(dest => dest.Video, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.Video) ? null : src.Video))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.Description) ? null : src.Description))
                .ReverseMap();
            CreateMap<Film, CreateFilmResponseDto>().ReverseMap();

            //Update
            CreateMap<UpdateFilmCommandRequest, Film>().ReverseMap();
            CreateMap<Film, UpdateFilmResponseDto>().ReverseMap();

            //Delete
            CreateMap<DeleteFilmCommandRequest, Film>().ReverseMap();
            CreateMap<Film, DeleteFilmResponseDto>().ReverseMap();
        }
    }
}
