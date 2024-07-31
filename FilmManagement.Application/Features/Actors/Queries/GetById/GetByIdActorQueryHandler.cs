using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Actors.Queries.GetById
{
    public class GetByIdActorQueryHandler : IRequestHandler<GetByIdActorQueryRequest, ApiResponse<GetByIdActorResponseDto>>
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;

        public GetByIdActorQueryHandler(IMapper mapper, IActorService actorService)
        {
            _mapper = mapper;
            _actorService = actorService;
        }
        public async Task<ApiResponse<GetByIdActorResponseDto>> Handle(GetByIdActorQueryRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<Actor?> getActorResponse = await _actorService.GetAsync(
                 predicate: d => d.Id == request.Id,
                 withDeleted: true,
                 enableTracking: false);

            GetByIdActorResponseDto responseDto = _mapper.Map<GetByIdActorResponseDto>(getActorResponse.Data);
            return new ApiResponse<GetByIdActorResponseDto>(responseDto, getActorResponse.Message);
        }
    }
}
