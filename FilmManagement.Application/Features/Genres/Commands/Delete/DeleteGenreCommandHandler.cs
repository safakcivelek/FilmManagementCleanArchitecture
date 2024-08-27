using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Genres.Commands.Delete;
using FilmManagement.Application.Features.Genres.Dtos;
using FilmManagement.Application.Features.Genres.Rules;
using FilmManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagement.Application.Features.Genres.Commands.Delete
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommandRequest, ApiResponse<DeleteGenreResponseDto>>
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly GenreBusinessRules _genreBusinessRules;

        public DeleteGenreCommandHandler(IGenreService genreService, IMapper mapper, GenreBusinessRules genreBusinessRules)
        {
            _genreService = genreService;
            _mapper = mapper;
            _genreBusinessRules = genreBusinessRules;
        }
        public async Task<ApiResponse<DeleteGenreResponseDto>> Handle(DeleteGenreCommandRequest request, CancellationToken cancellationToken)
        {
            await _genreBusinessRules.GenreShouldExistWhenUpdated(request.Id);

            ApiResponse<Genre?> getGenreResponse = await _genreService.GetAsync(d => d.Id == request.Id);

            Genre? genre = _mapper.Map(request, getGenreResponse.Data);

            ApiResponse<Genre> deletedGenre = await _genreService.DeleteAsync(genre);

            DeleteGenreResponseDto responseDto = _mapper.Map<DeleteGenreResponseDto>(deletedGenre.Data);
            return new ApiResponse<DeleteGenreResponseDto>(responseDto, deletedGenre.Message);
        }
    }
}
