using Proje.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Services.Abstract
{
    public interface IFilmService : IBaseService<Film>
    {

        List<Film> GetAllIncludeOyuncularKategoriler();
        Film GetFilmIncludeOyuncularKategorilerById(int id);
    }
}
