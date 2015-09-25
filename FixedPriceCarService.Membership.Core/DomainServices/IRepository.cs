using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FixedPriceCarService.Membership.Core.DomainServices
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        void Save();
    }
}
