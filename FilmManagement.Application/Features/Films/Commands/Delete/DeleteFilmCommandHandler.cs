using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Delete
{
    public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommandRequest, ApiResponse<DeleteFilmResponseDto>>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public DeleteFilmCommandHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<DeleteFilmResponseDto>> Handle(DeleteFilmCommandRequest request, CancellationToken cancellationToken)
        {
            Film film = await _filmRepository.GetAsync(predicate: f => f.Id == request.Id);

            await _filmRepository.DeleteAsync(film!,forceDelete: false);

            //ApiResponse<DeleteFilmResponseDto> response = _mapper.Map<ApiResponse<DeleteFilmResponseDto>>(film);
            //return response;

            DeleteFilmResponseDto filmDto = _mapper.Map<DeleteFilmResponseDto>(film);
            return new ApiResponse<DeleteFilmResponseDto>(filmDto, "Film başarıyla silindi.");
        }
    }
}
