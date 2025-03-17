using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
    
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("cast")]
        public async Task<IActionResult> AddCast([FromBody] CreateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok(command);
        }

        [HttpGet("cast/{Id}")]
        public async Task<IActionResult> GetCastById(int Id)
        {
            var cast = await _mediator.Send(new GetCastByIdQuery(Id));
            return Ok(cast);
        }

        [HttpGet("casts")]
        public async Task<IActionResult> GetAllCasts()
        {
            var casts = await _mediator.Send(new GetCastQuery());
            return Ok(casts);
        }

        [HttpDelete("cast/{Id}")]
        public async Task<IActionResult> DeleteCast(int Id)
        {
            await _mediator.Send(new RemoveCastCommand(Id));
            return Ok(Id);
        }

        [HttpPut("cast")]
        public async Task<IActionResult> UpdateCast([FromBody]UpdateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok(command);
        }


    }
}
