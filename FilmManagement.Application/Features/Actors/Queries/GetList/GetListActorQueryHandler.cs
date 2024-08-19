﻿using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Actors.Queries.GetList
{
    public class GetListActorQueryHandler : IRequestHandler<GetListActorQueryRequest, ApiPagedResponse<GetListActorResponseDto>>
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;

        public GetListActorQueryHandler(IMapper mapper, IActorService actorService)
        {
            _mapper = mapper;
            _actorService = actorService;
        }
        public async Task<ApiPagedResponse<GetListActorResponseDto>> Handle(GetListActorQueryRequest request, CancellationToken cancellationToken)
        {
            ApiPagedResponse<Actor> getActorsResponse = await _actorService.GetListAsync(
                 withDeleted: false,
                 enableTracking: false
                 );

            IList<GetListActorResponseDto> responseDto = _mapper.Map<IList<GetListActorResponseDto>>(getActorsResponse.Data);
            return new ApiPagedResponse<GetListActorResponseDto>(responseDto, getActorsResponse.Message);
        }
    }
}
