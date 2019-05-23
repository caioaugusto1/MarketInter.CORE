using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Inter.Core.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private readonly DbContextOptions<ContextDB> _OptionsBuilder;

        public RepositoryBase()
        {
            _OptionsBuilder = new DbContextOptions<ContextDB>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindByFilter(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity obj)
        {
            using (var db = new Inter.Core.Infra.Data.Context.ContextDB(_OptionsBuilder))
            {
                db.Set<TEntity>().Add(obj);
                db.SaveChangesAsync();
            }
        }


        public TEntity Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}

