﻿using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieQueryHandler(MovieContext context)
        {
            _context = context; 
        }


        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var values = await _context.Movies.ToListAsync();
            return values.Select(x => new GetMovieQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Duration = x.Duration,
                ReleaseDate = x.ReleaseDate, 
                Rating = x.Rating,
                CreatedDate = x.CreatedDate,
                Status = x.Status
            }).ToList();
        }
    }
}
