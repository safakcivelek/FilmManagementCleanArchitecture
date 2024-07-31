using AutoMapper;
using FilmManagement.Application.Features.Directors.Commands.Create;
using FilmManagement.Application.Features.Directors.Commands.Delete;
using FilmManagement.Application.Features.Directors.Commands.Update;
using FilmManagement.Application.Features.Directors.Dtos;
using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Features.Directors.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //GetList
            CreateMap<Director, GetListDirectorResponseDto>().ReverseMap();

            //GetById
            CreateMap<Director, GetByIdDirectorResponseDto>().ReverseMap();

            //Add
            CreateMap<CreateDirectorCommandRequest, Director>().ReverseMap();
            CreateMap<Director, CreateDirectorResponseDto>().ReverseMap();

            //Update
            CreateMap<UpdateDirectorCommandRequest, Director>().ReverseMap();
            CreateMap<Director, UpdateDirectorResponseDto>().ReverseMap();

            //Delete
            CreateMap<DeleteDirectorCommandRequest, Director>().ReverseMap();
            CreateMap<Director, DeleteDirectorResponseDto>().ReverseMap();
        }
    }
}
