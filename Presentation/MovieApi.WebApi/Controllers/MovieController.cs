using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Command.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

        public MovieController(GetMovieQueryHandler getMovieQueryHandler, GetMovieByIdQueryHandler getMovieByIdQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler)
        {
            _getMovieQueryHandler = getMovieQueryHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }

        [HttpGet("movies")]
        public async Task<IActionResult> MovieList()
        {
            var result = await _getMovieQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("movie/{Id}")]
        public async Task<IActionResult>GetMovieById(int Id)
        {
            var result = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(Id));
            return Ok(result);
        }

        [HttpPost("movie")]

        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Movie Added");
        }

        [HttpDelete("movie/{Id}")]
        public async Task<IActionResult> DeleteMovie(int Id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(Id));
            return Ok("Movie Deleted");
        }

        [HttpPut("movie")]
        public async Task<IActionResult> UpdateMovie( [FromBody] UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Movie Updated");
        }
    }
}
