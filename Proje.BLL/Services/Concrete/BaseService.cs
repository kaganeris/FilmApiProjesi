using Proje.BLL.Services.Abstract;
using Proje.CORE.Entities;
using Proje.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Services.Concrete
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public bool Add(T entity)
        {
            if (entity == null)
                return false;
            else
                return baseRepository.Add(entity);
        }
        public bool Update(T entity)
        {
            if (entity == null)
                return false;
            else
                return baseRepository.Update(entity);
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                return false;
            else
                return baseRepository.Delete(id);
        }

        public List<T> GetAll() => baseRepository.GetAll();

        public T GetByID(int id)
        {
            if (id <= 0)
                return null;
            else
                return baseRepository.GetByID(id);
        }

        public T GetWhere(Expression<Func<T, bool>> exp)
        {
            if (exp == null)
                return null;
            else
                return baseRepository.GetWhere(exp);
        }

        public List<T> GetWhereAll(Expression<Func<T, bool>> exp) => baseRepository.GetWhereAll(exp);

        
    }
}
