using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Delete
{
    public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommandRequest, DeleteFilmCommandResponse>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public DeleteFilmCommandHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<DeleteFilmCommandResponse> Handle(DeleteFilmCommandRequest request, CancellationToken cancellationToken)
        {
            Film film = await _filmRepository.GetAsync(predicate: f => f.Id == request.Id);

            await _filmRepository.DeleteAsync(film!,forceDelete: false);

            DeleteFilmCommandResponse response = _mapper.Map<DeleteFilmCommandResponse>(film);
            return response;
        }
    }
}
