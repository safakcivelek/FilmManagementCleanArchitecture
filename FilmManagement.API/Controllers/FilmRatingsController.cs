using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.FilmRatings.Commands.Create;
using FilmManagement.Application.Features.FilmRatings.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmRatingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilmRatingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddRating([FromBody] CreateFilmRatingCommandRequest request)
        {
            ApiResponse<CreateFilmRatingResponseDto> response = await _mediator.Send(request);         
            return Ok(response);
        }
    }
}
