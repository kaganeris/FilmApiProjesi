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
    public class KategoriService : BaseService<Kategori>, IKategoriService
    {
        private readonly IKategoriRepository kategoriRepository;

        public KategoriService(IBaseRepository<Kategori> baseRepository,IKategoriRepository kategoriRepository) : base(baseRepository)
        {
            this.kategoriRepository = kategoriRepository;
        }

        public List<Kategori> GetAllKategoriIncludeFilmler()
        {
            return kategoriRepository.GetAllIncludeFilmler();
        }

        public Kategori GetKategoriIncludeFilmlerById(int id)
        {
            if (id <= 0)
                return null;
            else
                return kategoriRepository.GetKategoriIncludeFilmById(id);
        }
    }
}
