using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Directors.Commands.Create;
using FilmManagement.Application.Features.Directors.Commands.Delete;
using FilmManagement.Application.Features.Directors.Commands.Update;
using FilmManagement.Application.Features.Directors.Dtos;
using FilmManagement.Application.Features.Directors.Queries.GetById;
using FilmManagement.Application.Features.Directors.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DirectorManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DirectorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            ApiResponse<GetByIdDirectorResponseDto> response = await _mediator.Send(new GetByIdDirectorQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListDirectorQueryRequest request)
        {
            ApiListResponse<GetListDirectorResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDirectorCommandRequest request)
        {
            ApiResponse<CreateDirectorResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDirectorCommandRequest request)
        {
            ApiResponse<UpdateDirectorResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            ApiResponse<DeleteDirectorResponseDto> response = await _mediator.Send(new DeleteDirectorCommandRequest { Id = id });
            return Ok(response);
        }
    }
}
