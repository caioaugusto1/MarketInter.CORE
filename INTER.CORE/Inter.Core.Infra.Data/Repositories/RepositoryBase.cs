using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            GC.SuppressFinalize(true);
        }

        public Task<List<TEntity>> FindByFilter(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = new ContextDB(_OptionsBuilder))
            {
                return db.Set<TEntity>().Where(predicate).ToListAsync();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var db = new ContextDB(_OptionsBuilder))
            {
                return db.Set<TEntity>().AsNoTracking().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (var db = new ContextDB(_OptionsBuilder))
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        public TEntity Insert(TEntity obj)
        {
            using (var db = new ContextDB(_OptionsBuilder))
            {
                var entity = db.Set<TEntity>().Add(obj);
                db.SaveChangesAsync();

                return entity.Entity;
            }
        }


        public TEntity Update(TEntity obj)
        {
            using (var db = new ContextDB(_OptionsBuilder))
            {
                var entity = db.Set<TEntity>().Update(obj);
                db.SaveChangesAsync();

                return entity.Entity;
            }
        }
    }
}

