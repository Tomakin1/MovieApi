﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Command.MovieCommands
{
    public class RemoveMovieCommand
    {
        public RemoveMovieCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
