using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Create
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommandRequest, CreateFilmCommandResponse>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public CreateFilmCommandHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<CreateFilmCommandResponse> Handle(CreateFilmCommandRequest request, CancellationToken cancellationToken)
        {
            Film film = _mapper.Map<Film>(request);
            await _filmRepository.AddAsync(film);

            CreateFilmCommandResponse response = _mapper.Map<CreateFilmCommandResponse>(film);
            return response;
        }
    }
}
