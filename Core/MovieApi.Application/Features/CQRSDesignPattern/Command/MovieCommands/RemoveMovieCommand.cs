﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Command.MovieCommands
{
    class RemoveMovieCommand
    {
        public int Id { get; set; }
    }
}
