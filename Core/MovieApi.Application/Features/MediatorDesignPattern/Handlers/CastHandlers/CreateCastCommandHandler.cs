using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _context;

        public CreateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            await _context.Casts.AddAsync(new Cast
            {
                Name = request.Name,
                Biography = request.Biography,
                Overview = request.Overview,
                Title = request.Title,
                Surname = request.Surname,
                ImageUrl = request.ImageUrl,
                
            });
            await _context.SaveChangesAsync();
        }
    }
}
