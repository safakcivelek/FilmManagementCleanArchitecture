using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Directors.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Directors.Queries.GetById
{
    public class GetByIdDirectorQueryHandler : IRequestHandler<GetByIdDirectorQueryRequest, ApiResponse<GetByIdDirectorResponseDto>>
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper _mapper;

        public GetByIdDirectorQueryHandler(IMapper mapper, IDirectorService directorService)
        {
            _mapper = mapper;
            _directorService = directorService;
        }
        public async Task<ApiResponse<GetByIdDirectorResponseDto>> Handle(GetByIdDirectorQueryRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<Director?> getDirectorResponse = await _directorService.GetAsync(
                 predicate: d => d.Id == request.Id,
                 withDeleted: true,
                 enableTracking: false);

            GetByIdDirectorResponseDto responseDto = _mapper.Map<GetByIdDirectorResponseDto>(getDirectorResponse.Data);
            return new ApiResponse<GetByIdDirectorResponseDto>(responseDto, getDirectorResponse.Message);
        }
    }
}
