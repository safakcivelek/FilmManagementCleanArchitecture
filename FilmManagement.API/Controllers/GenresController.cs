using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Genres.Commands.Create;
using FilmManagement.Application.Features.Genres.Commands.Delete;
using FilmManagement.Application.Features.Genres.Commands.Update;
using FilmManagement.Application.Features.Genres.Dtos;
using FilmManagement.Application.Features.Genres.Queries.GetById;
using FilmManagement.Application.Features.Genres.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            ApiResponse<GetByIdGenreResponseDto> response = await _mediator.Send(new GetByIdGenreQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListGenreQueryRequest request)
        {
            ApiPagedResponse<GetListGenreResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGenreCommandRequest request)
        {
            ApiResponse<CreateGenreResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGenreCommandRequest request)
        {
            ApiResponse<UpdateGenreResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            ApiResponse<DeleteGenreResponseDto> response = await _mediator.Send(new DeleteGenreCommandRequest { Id = id });
            return Ok(response);
        }
    }
}
