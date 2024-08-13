﻿using FilmManagement.Application.Common.Responses;
using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IFilmRatingService
    {
        Task<ApiResponse<FilmRating>> AddRatingAsync(FilmRating rating);
        Task<double> CalculateFilmRatingAsync(Guid filmId);
    }
}