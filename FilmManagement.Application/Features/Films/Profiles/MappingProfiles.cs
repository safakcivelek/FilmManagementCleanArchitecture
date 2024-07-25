using AutoMapper;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Commands.Create;
using FilmManagement.Application.Features.Films.Commands.Delete;
using FilmManagement.Application.Features.Films.Commands.Update;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Application.Features.Films.Queries.GetById;
using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Features.Films.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //GetList
            CreateMap<IList<Film>, GetListResponse<GetListFilmDto>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src =>
                    src.Select(x => new GetListFilmDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Year = x.Year,
                        Price = x.Price,
                        Description = x.Description
                    }).ToList()));

            //GetById
            CreateMap<Film, GetByIdFilmQueryResponse>().ReverseMap();

            //Add
            CreateMap<CreateFilmCommandRequest, Film>();
            CreateMap<Film, CreateFilmCommandResponse>();

            //Update
            CreateMap<UpdateFilmCommandRequest, Film>().ReverseMap();
            CreateMap<Film, UpdateFilmCommandResponse>().ReverseMap();

            //Delete
            CreateMap<Film, DeleteFilmCommandResponse>().ReverseMap();

        }
    }
}
