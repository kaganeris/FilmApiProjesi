using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Services.Abstract
{
    public interface IBaseService<T>
    {
        T GetByID(int id);
        List<T> GetAll();
        T GetWhere(Expression<Func<T, bool>> exp);
        List<T> GetWhereAll(Expression<Func<T, bool>> exp);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
