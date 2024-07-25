﻿using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Commands.Create;
using FilmManagement.Application.Features.Films.Commands.Delete;
using FilmManagement.Application.Features.Films.Commands.Update;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Application.Features.Films.Queries.GetById;
using FilmManagement.Application.Features.Films.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FilmManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilmsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdFilmQueryResponse response = await _mediator.Send(new GetByIdFilmQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListFilmQueryRequest request)
        {
            GetListResponse<GetListFilmDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFilmCommandRequest request)
        {
            CreateFilmCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFilmCommandRequest request)
        {
            UpdateFilmCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteFilmCommandResponse response = await _mediator.Send(new DeleteFilmCommandRequest { Id = id});
            return Ok(response);
        }
    }
}