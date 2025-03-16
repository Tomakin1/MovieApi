using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Command.CategoryCommands
{
    public class RemoveCategoryCommand
    {
        public RemoveCategoryCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
