using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixedPriceCarService.Membership.Core.DomainServices;
using FixedPriceCarService.Membership.Core.Entities;

namespace FixedPriceCarService.Membership.Infrastructure.DomainServices
{
    public abstract class BaseRepository<TEntity>
        : IRepository<TEntity> where TEntity: class
    {
        private IEnumerable<TEntity> _list;
        public BaseRepository()
        {
            _list = new List<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
