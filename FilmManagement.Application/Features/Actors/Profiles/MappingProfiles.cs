using AutoMapper;
using FilmManagement.Application.Features.Actors.Commands.Create;
using FilmManagement.Application.Features.Actors.Commands.Delete;
using FilmManagement.Application.Features.Actors.Commands.Update;
using FilmManagement.Application.Features.Actors.Dtos;
using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Features.Actors.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //GetList
            CreateMap<Actor, GetListActorResponseDto>().ReverseMap();

            //GetById
            CreateMap<Actor, GetByIdActorResponseDto>().ReverseMap();

            //Add
            CreateMap<CreateActorCommandRequest, Actor>().ReverseMap();
            CreateMap<Actor, CreateActorResponseDto>().ReverseMap();

            //Update
            CreateMap<UpdateActorCommandRequest, Actor>().ReverseMap();
            CreateMap<Actor, UpdateActorResponseDto>().ReverseMap();

            //Delete
            CreateMap<DeleteActorCommandRequest, Actor>().ReverseMap();
            CreateMap<Actor, DeleteActorResponseDto>().ReverseMap();
        }
    }
}
