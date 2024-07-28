using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Update
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommandRequest, ApiResponse<UpdateFilmResponseDto>>
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;

        public UpdateFilmCommandHandler(IFilmService filmService, IMapper mapper)
        {
            _filmService = filmService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UpdateFilmResponseDto>> Handle(UpdateFilmCommandRequest request, CancellationToken cancellationToken)
        {      
            //film varmı kontrolü yapılmalı!
            ApiResponse<Film?> getFilmResponse = await _filmService.GetAsync(f => f.Id == request.Id);

            Film? film = _mapper.Map(request, getFilmResponse.Data);
            ApiResponse<Film> updatedFilm = await _filmService.UpdateAsync(film);

            //güncelleme başarısız olması durumunda updatedResponse.Data 'nın null kontrolu vb durumlar için kontrolü yapacakmıyım burada ??

            UpdateFilmResponseDto responseDto =_mapper.Map<UpdateFilmResponseDto>(updatedFilm.Data);
            return new ApiResponse<UpdateFilmResponseDto>(responseDto, updatedFilm.Message);
        }
    }
}
