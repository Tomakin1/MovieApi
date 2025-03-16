using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults
{
    class GetCategoryByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
