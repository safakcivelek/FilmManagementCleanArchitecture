using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Commands.Create;
using FilmManagement.Application.Features.Actors.Commands.Delete;
using FilmManagement.Application.Features.Actors.Commands.Update;
using FilmManagement.Application.Features.Actors.Dtos;
using FilmManagement.Application.Features.Actors.Queries.GetById;
using FilmManagement.Application.Features.Actors.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FilmManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            ApiResponse<GetByIdActorResponseDto> response = await _mediator.Send(new GetByIdActorQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListActorQueryRequest request)
        {
            ApiListResponse<GetListActorResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateActorCommandRequest request)
        {
            ApiResponse<CreateActorResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateActorCommandRequest request)
        {
            ApiResponse<UpdateActorResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            ApiResponse<DeleteActorResponseDto> response = await _mediator.Send(new DeleteActorCommandRequest { Id = id });
            return Ok(response);
        }
    }
}
