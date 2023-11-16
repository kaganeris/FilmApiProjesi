using Proje.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.CORE.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T GetByID(int id);
        List<T> GetAll();
        T GetWhere(Expression<Func<bool,T>> exp);
        List<T> GetWhereAll(Expression<Func<bool,T>> exp);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        void Save();
    }
}
