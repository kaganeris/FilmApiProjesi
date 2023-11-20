using Proje.BLL.Services.Abstract;
using Proje.CORE.Entities;
using Proje.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Services.Concrete
{
    public class FilmService : BaseService<Film>, IFilmService
    {
        private readonly IFilmRepository filmRepository;

        public FilmService(IBaseRepository<Film> baseRepository, IFilmRepository filmRepository) : base(baseRepository)
        {
            this.filmRepository = filmRepository;
        }

        public object GetAllIncludeOyuncularKategoriler()
        {
            return filmRepository.GetAllIncludeOyuncuKategori();
        }

        public Film GetFilmIncludeOyuncularKategorilerById(int id)
        {
            if (id <= 0)
                return null;
            else
                return filmRepository.GetFilmIncludeOyuncularKategorilerById(id);
        }
    }
}
