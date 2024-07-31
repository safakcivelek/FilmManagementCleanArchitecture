using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Directors.Dtos;
using FilmManagement.Application.Features.Directors.Rules;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Directors.Commands.Delete
{
    public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommandRequest, ApiResponse<DeleteDirectorResponseDto>>
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper _mapper;
        private readonly DirectorBusinessRules _directorBusinessRules;

        public DeleteDirectorCommandHandler(IDirectorService directorService, IMapper mapper, DirectorBusinessRules directorBusinessRules)
        {
            _directorService = directorService;
            _mapper = mapper;
            _directorBusinessRules = directorBusinessRules;
        }
        public async Task<ApiResponse<DeleteDirectorResponseDto>> Handle(DeleteDirectorCommandRequest request, CancellationToken cancellationToken)
        {
            await _directorBusinessRules.DirectorShouldExistWhenUpdated(request.Id);

            ApiResponse<Director?> getDirectorResponse = await _directorService.GetAsync(d => d.Id == request.Id);

            Director? director =_mapper.Map(request, getDirectorResponse.Data);

            ApiResponse<Director> deletedDirector =await _directorService.DeleteAsync(director);

            DeleteDirectorResponseDto responseDto =_mapper.Map<DeleteDirectorResponseDto>(deletedDirector.Data);
            return new ApiResponse<DeleteDirectorResponseDto>(responseDto, deletedDirector.Message);
        }
    }
}
