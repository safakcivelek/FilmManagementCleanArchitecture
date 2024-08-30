using AutoMapper;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Application.Features.Purchases.Commands.Create;
using FilmManagement.Application.Features.Purchases.Dtos;
using FilmManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagement.Application.Features.Purchases.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Create
            CreateMap<CreatePurchaseCommandRequest, Purchase>().ReverseMap();
            CreateMap<Purchase, CreatePurchaseResponseDto>().ReverseMap();

            //GetList
            CreateMap<Purchase, GetListPurchaseResponseDto>()
                  .ForMember(dest => dest.FilmName, opt => opt.MapFrom(src => src.Film.Name)).ReverseMap();
        }
    }
}
