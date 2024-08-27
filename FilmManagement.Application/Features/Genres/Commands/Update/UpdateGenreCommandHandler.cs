using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Genres.Dtos;
using FilmManagement.Application.Features.Genres.Rules;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Genres.Commands.Update
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommandRequest, ApiResponse<UpdateGenreResponseDto>>
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly GenreBusinessRules _genreBusinessRules;

        public UpdateGenreCommandHandler(IGenreService genreService, IMapper mapper, GenreBusinessRules genreBusinessRules)
        {
            _genreService = genreService;
            _mapper = mapper;
            _genreBusinessRules = genreBusinessRules;
        }

        public async Task<ApiResponse<UpdateGenreResponseDto>> Handle(UpdateGenreCommandRequest request, CancellationToken cancellationToken)
        {
            await _genreBusinessRules.GenreShouldExistWhenUpdated(request.Id);

            ApiResponse<Genre?> getGenreResponse = await _genreService.GetAsync(d => d.Id == request.Id);

            Genre? genre = _mapper.Map(request, getGenreResponse.Data);
            ApiResponse<Genre> updatedGenre = await _genreService.UpdateAsync(genre);

            UpdateGenreResponseDto responseDto = _mapper.Map<UpdateGenreResponseDto>(updatedGenre.Data);
            return new ApiResponse<UpdateGenreResponseDto>(responseDto, updatedGenre.Message);
        }
    }
}
