using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var movie = await _context.Movies.Where(m => m.Id == query.Id).Select(x => new GetMovieByIdQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Duration = x.Duration,
                ReleaseDate = x.ReleaseDate,
                Rating = x.Rating,
                CreatedDate = x.CreatedDate,
                Status = x.Status,
                CoverImageUrl = x.CoverImageUrl
            }).FirstOrDefaultAsync();
            if (movie is not null)
            {
                return movie;
            }
            return null;
        }
    }
}
