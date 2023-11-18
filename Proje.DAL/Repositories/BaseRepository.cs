using Proje.CORE.Entities;
using Proje.CORE.Repositories;
using Proje.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public bool Add(T entity)
        {
            entity.OlusturmaTarihi = DateTime.Now;
            entity.AktifMi = true;
            context.Set<T>().Add(entity);
            return Save() > 0;
        }
        public bool Update(T entity)
        {
            entity.GuncellemeTarihi = DateTime.Now;
            entity.AktifMi = true;
            context.Set<T>().Update(entity);
            return Save() > 0;
        }

        public bool Delete(int id)
        {
            var entity = GetByID(id);
            entity.AktifMi = false;
            entity.SilinmeTarihi = DateTime.Now;
            context.Set<T>().Update(entity);
            return Save() > 0;
        }

        public List<T> GetAll() => context.Set<T>().ToList();

        public T GetByID(int id) => context.Set<T>().Where(x => x.ID == id).FirstOrDefault();
        

        public T GetWhere(Expression<Func<T, bool>> exp) => context.Set<T>().Where(exp).FirstOrDefault();

        public List<T> GetWhereAll(Expression<Func<T, bool>> exp) => context.Set<T>().Where(exp).ToList();

        public int Save() => context.SaveChanges();

        
    }
}
