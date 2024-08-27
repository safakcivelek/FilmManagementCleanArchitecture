using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Genres.Dtos;
using FilmManagement.Application.Features.Genres.Rules;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Genres.Commands.Create
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommandRequest, ApiResponse<CreateGenreResponseDto>>
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly GenreBusinessRules _genreBusinessRules;

        public CreateGenreCommandHandler(IMapper mapper, IGenreService genreService, GenreBusinessRules genreBusinessRules)
        {
            _mapper = mapper;
            _genreService = genreService;
            _genreBusinessRules = genreBusinessRules;
        }

        public async Task<ApiResponse<CreateGenreResponseDto>> Handle(CreateGenreCommandRequest request, CancellationToken cancellationToken)
        {
            Genre genre = _mapper.Map<Genre>(request);
            ApiResponse<Genre> addedGenre = await _genreService.AddAsync(genre);

            CreateGenreResponseDto responseDto = _mapper.Map<CreateGenreResponseDto>(addedGenre.Data);
            return new ApiResponse<CreateGenreResponseDto>(responseDto, addedGenre.Message);
        }
    }
}
