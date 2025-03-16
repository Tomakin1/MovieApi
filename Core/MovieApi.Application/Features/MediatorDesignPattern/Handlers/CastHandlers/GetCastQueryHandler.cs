using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _context;
        public GetCastQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.Select(c=> new GetCastQueryResult
            {
                Id=c.Id,
                Biography=c.Biography,
                ImageUrl=c.ImageUrl,
                Name=c.Name,
                Overview = c.Overview,
                Surname=c.Surname,
                Title = c.Title,
                
            }).ToListAsync();

            return values;
            
        }
    }
}
