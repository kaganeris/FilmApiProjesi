using Proje.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Services.Abstract
{
    public interface IKategoriService : IBaseService<Kategori>
    {
        Kategori GetKategoriIncludeFilmlerById(int id);
        List<Kategori> GetAllKategoriIncludeFilmler();
    }
}
