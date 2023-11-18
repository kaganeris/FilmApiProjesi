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

        // İsteklere göre doldurulabilir.
    }
}
