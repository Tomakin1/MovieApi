using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    public class RemoveCastCommand : IRequest
    {
        public RemoveCastCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }

    }
}
