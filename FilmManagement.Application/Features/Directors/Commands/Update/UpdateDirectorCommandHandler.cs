using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Directors.Dtos;
using FilmManagement.Application.Features.Directors.Rules;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Directors.Commands.Update
{
    public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommandRequest, ApiResponse<UpdateDirectorResponseDto>>
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper _mapper;
        private readonly DirectorBusinessRules _directorBusinessRules;

        public UpdateDirectorCommandHandler(IDirectorService directorService, IMapper mapper, DirectorBusinessRules directorBusinessRules)
        {
            _directorService = directorService;
            _mapper = mapper;
            _directorBusinessRules = directorBusinessRules;
        }

        public async Task<ApiResponse<UpdateDirectorResponseDto>> Handle(UpdateDirectorCommandRequest request, CancellationToken cancellationToken)
        {
            await _directorBusinessRules.DirectorShouldExistWhenUpdated(request.Id);

            ApiResponse<Director?> getDirectorResponse = await _directorService.GetAsync(d => d.Id == request.Id);

            Director? director = _mapper.Map(request, getDirectorResponse.Data);
            ApiResponse<Director> updatedDirector = await _directorService.UpdateAsync(director);

            UpdateDirectorResponseDto responseDto = _mapper.Map<UpdateDirectorResponseDto>(updatedDirector.Data);
            return new ApiResponse<UpdateDirectorResponseDto>(responseDto,updatedDirector.Message);
        }
    }
}
