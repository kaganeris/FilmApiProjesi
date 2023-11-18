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
        T GetWhere(Expression<Func<T,bool>> exp);
        List<T> GetWhereAll(Expression<Func<T, bool>> exp);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        int Save();
    }
}
