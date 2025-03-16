using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults
{
    public class GetMovieByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; } // Film Kaç Dakika Sürüyor
        public DateTime ReleaseDate { get; set; } // Film Ne Zaman Yayınlandı
        public string CreatedDate { get; set; } // Film Veritabanına Ne Zaman Eklendi
        public bool Status { get; set; } // Fim Aktif Olarak Sitede Var  mı
    }
}
