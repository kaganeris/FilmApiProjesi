using Microsoft.EntityFrameworkCore;
using Proje.CORE.Entities;
using Proje.CORE.Repositories;
using Proje.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.Repositories
{
    public class KategoriRepository : BaseRepository<Kategori>,IKategoriRepository
    {
        private readonly AppDbContext context;

        public KategoriRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public List<Kategori> GetAllIncludeFilmler()
        {
            return context.Kategoriler.Include(x => x.FilmlerKategoriler).ToList();
        }

        public Kategori GetKategoriIncludeFilmById(int id)
        {
            return context.Kategoriler.Include(x => x.FilmlerKategoriler).Where(x => x.ID == id).FirstOrDefault();
        }
    }
}
