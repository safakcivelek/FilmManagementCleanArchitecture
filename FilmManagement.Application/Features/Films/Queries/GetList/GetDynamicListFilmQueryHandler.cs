using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Application.Features.Films.Queries.GetList;
using FilmManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetDynamicListFilmQueryHandler : IRequestHandler<GetListFilmQueryRequest, ApiPagedResponse<GetListFilmResponseDto>>
{
    private readonly IFilmService _filmService;
    private readonly IMapper _mapper;

    public GetDynamicListFilmQueryHandler(IMapper mapper, IFilmService filmService)
    {
        _mapper = mapper;
        _filmService = filmService;
    }

    public async Task<ApiPagedResponse<GetListFilmResponseDto>> Handle(GetListFilmQueryRequest request, CancellationToken cancellationToken)
    {       
        int count = await _filmService.CountAsync(
            predicate: null, 
            withDeleted: false,
            enableTracking: false
        );  

        IList<Film> getFilmsResponse = await _filmService.GetFilmsByDynamicAsync(
            dynamicQuery: request.DynamicQuery,
            
            include: film => film
                         .Include(film => film.Director)
                         .Include(film => film.FilmGenres)
                            .ThenInclude(filmGenre => filmGenre.Genre)
                         .Include(film => film.FilmActors)
                            .ThenInclude(filmActor => filmActor.Actor),

            withDeleted: false,
            enableTracking: false,          
            skip:request.Start,
            take: request.Limit
            );
     

        IList<GetListFilmResponseDto> responseDto = _mapper.Map<IList<GetListFilmResponseDto>>(getFilmsResponse);
        return new ApiPagedResponse<GetListFilmResponseDto>(
            data: responseDto,
            totalCount: count,
            skip: request.Start,
            take: request.Limit,
            message: "Filmler başarıyla getirildi.",
            200
            );
    }
}
