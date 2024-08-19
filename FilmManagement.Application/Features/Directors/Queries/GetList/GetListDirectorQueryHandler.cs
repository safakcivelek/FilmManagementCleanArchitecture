using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Directors.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Directors.Queries.GetList
{
    public class GetListDirectorQueryHandler : IRequestHandler<GetListDirectorQueryRequest, ApiPagedResponse<GetListDirectorResponseDto>>
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper _mapper;

        public GetListDirectorQueryHandler(IMapper mapper, IDirectorService directorService)
        {
            _mapper = mapper;
            _directorService = directorService;
        }
        public async Task<ApiPagedResponse<GetListDirectorResponseDto>> Handle(GetListDirectorQueryRequest request, CancellationToken cancellationToken)
        {
            ApiPagedResponse<Director> getDirectorsResponse = await _directorService.GetListAsync(
                 withDeleted: false,
                 enableTracking: false
                 );

            IList<GetListDirectorResponseDto> responseDto = _mapper.Map<IList<GetListDirectorResponseDto>>(getDirectorsResponse.Data);
            return new ApiPagedResponse<GetListDirectorResponseDto>(responseDto, getDirectorsResponse.Message);
        }
    }
}
