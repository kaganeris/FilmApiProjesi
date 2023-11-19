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
    public class OyuncuService : BaseService<Oyuncu>, IOyuncuService
    {
        private readonly IOyuncuRepository oyuncuRepository;

        public OyuncuService(IBaseRepository<Oyuncu> baseRepository, IOyuncuRepository oyuncuRepository) : base(baseRepository)
        {
            this.oyuncuRepository = oyuncuRepository;
        }

        public List<Oyuncu> GetAllIncludeFilmler()
        {
            return oyuncuRepository.GetAllIncludeFilmler();
        }

        public Oyuncu GetOyuncuIncludeFilmlerById(int id)
        {
            if (id <= 0)
                return null;
            else
                return oyuncuRepository.GetOyuncuIncludeFilmById(id);
        }
    }
}
