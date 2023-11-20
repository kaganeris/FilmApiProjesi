using Proje.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.CORE.Repositories
{
    public interface IFilmRepository : IBaseRepository<Film>
    {
        // İsteklere göre doldurulabilir.

        Film GetFilmIncludeOyuncularKategorilerById(int id);
        object GetAllIncludeOyuncuKategori();
    }
}
