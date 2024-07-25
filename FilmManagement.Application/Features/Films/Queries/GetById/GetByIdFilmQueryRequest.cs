using MediatR;

namespace FilmManagement.Application.Features.Films.Queries.GetById
{
    public class GetByIdFilmQueryRequest : IRequest<GetByIdFilmQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
