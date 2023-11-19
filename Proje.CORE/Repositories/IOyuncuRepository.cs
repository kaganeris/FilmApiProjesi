using Proje.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.CORE.Repositories
{
    public interface IOyuncuRepository : IBaseRepository<Oyuncu>
    {
        // İsteklere göre doldurulabilir.
        Oyuncu GetOyuncuIncludeFilmById(int id);
        List<Oyuncu> GetAllIncludeFilmler();
    }
}
