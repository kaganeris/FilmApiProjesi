using Proje.CORE.Entities;
using Proje.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.Repositories
{
    public class OyuncuRepository : BaseRepository<Oyuncu>
    {
        private readonly AppDbContext context;

        public OyuncuRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        // İsteklere göre doldurulabilir
    }
}
