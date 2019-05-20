using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Save();
    }
}
