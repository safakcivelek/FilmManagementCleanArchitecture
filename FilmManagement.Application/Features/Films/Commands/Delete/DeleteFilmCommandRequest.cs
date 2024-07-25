using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Delete
{
    public class DeleteFilmCommandRequest : IRequest<DeleteFilmCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
