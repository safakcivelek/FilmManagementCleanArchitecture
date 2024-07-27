using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Update
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommandRequest, ApiResponse<UpdateFilmResponseDto>>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public UpdateFilmCommandHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UpdateFilmResponseDto>> Handle(UpdateFilmCommandRequest request, CancellationToken cancellationToken)
        {
            Film? film = await _filmRepository.GetAsync(predicate: f => f.Id == request.Id);

            film = _mapper.Map(request,film);

            await _filmRepository.UpdateAsync(film!);

            //ApiResponse<UpdateFilmResponseDto> response = _mapper.Map<ApiResponse<UpdateFilmResponseDto>>(film);
            //return response;

            UpdateFilmResponseDto filmDto = _mapper.Map<UpdateFilmResponseDto>(film);
            return new ApiResponse<UpdateFilmResponseDto>(filmDto, "Film başarıyla güncellendi.");
        }
    }
}
