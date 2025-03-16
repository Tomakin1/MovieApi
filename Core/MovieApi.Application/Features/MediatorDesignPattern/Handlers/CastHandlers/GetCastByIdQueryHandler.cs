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
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Casts.Where(c => c.Id == request.Id).Select(c => new GetCastByIdQueryResult
            {
                Id = c.Id,
                Biography = c.Biography,
                ImageUrl = c.ImageUrl,
                Name = c.Name,
                Overview = c.Overview,
                Surname = c.Surname,
                Title = c.Title,
                
            }).FirstOrDefaultAsync();

            if (value is not null)
            {
                return value;
            }

            return null;
        }
    }
}
