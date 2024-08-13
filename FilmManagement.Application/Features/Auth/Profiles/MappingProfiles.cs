using AutoMapper;
using FilmManagement.Application.Features.Auth.Commands.Register;
using FilmManagement.Application.Features.Auth.Dtos;
using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // RegisterCommandRequest'den User'a eşleme
            CreateMap<RegisterCommandRequest, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)).ReverseMap();  // UserName olarak Email kullanılıyor.

            CreateMap<RegisterResponseDto, User>().ReverseMap();
        }
    }
}
