using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Create
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommandRequest, ApiResponse<CreateFilmResponseDto>>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public CreateFilmCommandHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CreateFilmResponseDto>> Handle(CreateFilmCommandRequest request, CancellationToken cancellationToken)
        {
            Film film = _mapper.Map<Film>(request);
            await _filmRepository.AddAsync(film);

            CreateFilmResponseDto responseDto = _mapper.Map<CreateFilmResponseDto>(film);
            return new ApiResponse<CreateFilmResponseDto>(responseDto, "Ekleme işlemi başarılı.");
        }
    }
}
