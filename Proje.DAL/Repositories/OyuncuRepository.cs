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
    public class OyuncuRepository : BaseRepository<Oyuncu>,IOyuncuRepository
    {
        private readonly AppDbContext context;

        public OyuncuRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public List<Oyuncu> GetAllIncludeFilmler()
        {
            return context.Oyuncular.Include(x => x.FilmlerOyuncular).ToList();
        }

        public Oyuncu GetOyuncuIncludeFilmById(int id)
        {
            return context.Oyuncular.Include(x => x.FilmlerOyuncular).Include(x => x.ID == id).FirstOrDefault();
        }
    }
}
