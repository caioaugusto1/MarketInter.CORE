using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

        void Insert(TEntity obj);

        TEntity Update(TEntity obj);

        IEnumerable<TEntity> FindByFilter(Expression<Func<TEntity, bool>> predicate);
        
    }
}
