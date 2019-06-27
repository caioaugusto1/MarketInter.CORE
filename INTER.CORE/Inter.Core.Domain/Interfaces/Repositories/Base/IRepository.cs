using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity GetById(Guid id);

        TEntity Insert(TEntity obj);

        TEntity Update(TEntity obj);

        List<TEntity> FindByFilter(Expression<Func<TEntity, bool>> predicate);

        void Delete(TEntity id);
        
    }
}
