using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Update
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommandRequest, UpdateFilmCommandResponse>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public UpdateFilmCommandHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<UpdateFilmCommandResponse> Handle(UpdateFilmCommandRequest request, CancellationToken cancellationToken)
        {
            Film? film = await _filmRepository.GetAsync(predicate: f => f.Id == request.Id);

            film = _mapper.Map(request,film);

            await _filmRepository.UpdateAsync(film!);

            UpdateFilmCommandResponse response = _mapper.Map<UpdateFilmCommandResponse>(film);
            return response;
        }
    }
}
