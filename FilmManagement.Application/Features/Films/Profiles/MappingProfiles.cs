using AutoMapper;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Commands.Create;
using FilmManagement.Application.Features.Films.Commands.Delete;
using FilmManagement.Application.Features.Films.Commands.Update;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Application.Features.Films.Queries.GetById;
using FilmManagement.Application.Features.Genres.Dtos;
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
            CreateMap<Film, GetByIdFilmResponseDto>().ReverseMap(); 
            

            //Add
            CreateMap<CreateFilmCommandRequest, Film>().ReverseMap();
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
