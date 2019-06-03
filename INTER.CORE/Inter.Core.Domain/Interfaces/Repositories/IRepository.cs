using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity Insert(TEntity obj);

        TEntity Update(TEntity obj);

        Task<List<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> predicate);
        
    }
}
