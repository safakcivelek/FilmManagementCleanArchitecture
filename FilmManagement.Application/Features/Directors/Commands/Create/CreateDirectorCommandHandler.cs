using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Directors.Dtos;
using FilmManagement.Application.Features.Directors.Rules;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Directors.Commands.Create
{
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommandRequest, ApiResponse<CreateDirectorResponseDto>>
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper _mapper;
        private readonly DirectorBusinessRules _directorBusinessRules;

        public CreateDirectorCommandHandler(IMapper mapper, IDirectorService directorService, DirectorBusinessRules directorBusinessRules)
        {
            _mapper = mapper;
            _directorService = directorService;
            _directorBusinessRules = directorBusinessRules;
        }

        public async Task<ApiResponse<CreateDirectorResponseDto>> Handle(CreateDirectorCommandRequest request, CancellationToken cancellationToken)
        {          
            Director director = _mapper.Map<Director>(request);
            ApiResponse<Director> addedDirector = await _directorService.AddAsync(director);

            CreateDirectorResponseDto responseDto = _mapper.Map<CreateDirectorResponseDto>(addedDirector.Data);
            return new ApiResponse<CreateDirectorResponseDto>(responseDto, addedDirector.Message);
        }
    }
}
