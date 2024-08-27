using AutoMapper;
using FilmManagement.Application.Features.Genres.Commands.Create;
using FilmManagement.Application.Features.Genres.Commands.Delete;
using FilmManagement.Application.Features.Genres.Commands.Update;
using FilmManagement.Application.Features.Genres.Dtos;
using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Features.Genres.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //GetList
            CreateMap<Genre, GetListGenreResponseDto>().ReverseMap();

            //GetById
            CreateMap<Genre, GetByIdGenreResponseDto>().ReverseMap();

            //Add
            CreateMap<CreateGenreCommandRequest, Genre>().ReverseMap();
            CreateMap<Genre, CreateGenreResponseDto>().ReverseMap();

            //Update
            CreateMap<UpdateGenreCommandRequest, Genre>().ReverseMap();
            CreateMap<Genre, UpdateGenreResponseDto>().ReverseMap();

            //Delete
            CreateMap<DeleteGenreCommandRequest, Genre>().ReverseMap();
            CreateMap<Genre, DeleteGenreResponseDto>().ReverseMap();
        }
    }
}
