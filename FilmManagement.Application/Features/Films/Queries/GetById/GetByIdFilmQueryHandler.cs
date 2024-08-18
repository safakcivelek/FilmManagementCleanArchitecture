﻿using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FilmManagement.Application.Features.Films.Queries.GetById
{
    public class GetByIdFilmQueryHandler : IRequestHandler<GetByIdFilmQueryRequest, ApiResponse<GetByIdFilmResponseDto>>
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;

        public GetByIdFilmQueryHandler(IMapper mapper, IFilmService filmService)
        {
            _mapper = mapper;
            _filmService = filmService;
        }

        public async Task<ApiResponse<GetByIdFilmResponseDto>> Handle(GetByIdFilmQueryRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<Film?> getFilmResponse = await _filmService.GetAsync(
                predicate: f => f.Id == request.Id,
                include: film => film
                              .Include(film => film.Director)
                             .Include(film => film.FilmGenres)
                                .ThenInclude(filmGenre => filmGenre.Genre)
                             .Include(film => film.FilmActors)
                                .ThenInclude(filmActor => filmActor.Actor),

                withDeleted: true,
                enableTracking: false);

            GetByIdFilmResponseDto responseDto = _mapper.Map<GetByIdFilmResponseDto>(getFilmResponse.Data);
            return new ApiResponse<GetByIdFilmResponseDto>(responseDto, getFilmResponse.Message);
        }
    }
}
