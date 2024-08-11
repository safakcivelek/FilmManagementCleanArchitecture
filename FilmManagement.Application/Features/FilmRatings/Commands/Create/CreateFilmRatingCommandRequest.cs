using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.FilmRatings.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.FilmRatings.Commands.Create
{
    public class CreateFilmRatingCommandRequest : IRequest<ApiResponse<CreateFilmRatingResponseDto>>
    {
        public Guid UserId { get; set; }
        public Guid FilmId { get; set; }
        public int Rating { get; set; }
    }
}
