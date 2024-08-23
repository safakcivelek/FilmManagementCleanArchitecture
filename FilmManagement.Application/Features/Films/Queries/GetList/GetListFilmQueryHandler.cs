using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FilmManagement.Application.Features.Films.Queries.GetList
{
    public class GetListFilmQueryHandler : IRequestHandler<GetListFilmQueryRequest, ApiPagedResponse<GetListFilmResponseDto>>
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;

        public GetListFilmQueryHandler(IMapper mapper, IFilmService filmService)
        {
            _mapper = mapper;
            _filmService = filmService;
        }

        public async Task<ApiPagedResponse<GetListFilmResponseDto>> Handle(GetListFilmQueryRequest request, CancellationToken cancellationToken)
        {
            // Toplam veri sayısını hesapla
            int count = await _filmService.CountAsync(
                predicate: null, // Filtreleme gerekirse burada uygulanabilir
                withDeleted: false,
                enableTracking: false
            );
         
            int skip = request.Start ?? 0; 
            int take = request.Limit ?? 10; 

            ApiPagedResponse<Film> getFilmsResponse = await _filmService.GetListAsync(
                include: film => film
                             .Include(film => film.Director)
                             .Include(film => film.FilmGenres)
                                .ThenInclude(filmGenre => filmGenre.Genre)
                             .Include(film => film.FilmActors)
                                .ThenInclude(filmActor => filmActor.Actor),

                withDeleted: false,
                enableTracking: false,
                skip: skip,
                take: take
                );

            IList<GetListFilmResponseDto> responseDto = _mapper.Map<IList<GetListFilmResponseDto>>(getFilmsResponse.Data);           
            return new ApiPagedResponse<GetListFilmResponseDto>(
                data: responseDto,
                totalCount: count,
                skip: skip,
                take: take,
                message: "Filmler başarıyla getirildi.",
                200
                );
        }
    }
}
