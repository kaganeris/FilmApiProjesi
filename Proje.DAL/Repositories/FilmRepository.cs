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
    public class FilmRepository : BaseRepository<Film>,IFilmRepository
    {
        private readonly AppDbContext context;

        public FilmRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public List<Film> GetAllIncludeOyuncuKategori()
        {
            return context.Filmler.Include(x => x.FilmlerOyuncular).Include(x => x.FilmlerKategoriler).ToList();
        }

        public Film GetFilmIncludeOyuncularKategorilerById(int id)
        {
            return context.Filmler.Include(x => x.FilmlerOyuncular).Include(x => x.FilmlerKategoriler).Where(x => x.ID == id).FirstOrDefault();
        }


    }
}
