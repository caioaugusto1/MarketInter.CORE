using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using Inter.Core.Infra.Data.Repositories.Base;
using Inter.Core.Infra.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Inter.Core.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private readonly DbContextOptions<MySQLContext> _OptionsBuilder;

        //private readonly IDbConnection _db;

        public RepositoryBase()
        {
            _OptionsBuilder = new DbContextOptions<MySQLContext>();
            //_db = new MySqlConnection("");
        }

        public void Delete(TEntity obj)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                db.Set<TEntity>().Remove(obj);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public List<TEntity> FindByFilter(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                return db.Set<TEntity>().Where(predicate).ToList();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                return db.Set<TEntity>().AsNoTracking().ToList();
            }
        }

        public TEntity GetById(Guid id)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        public TEntity Insert(TEntity obj)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                db.Entry(obj).State = EntityState.Added;
                var entity = db.Set<TEntity>().Add(obj);
                db.SaveChanges();

                return entity.Entity;
            }
        }


        public TEntity Update(TEntity obj)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                var entity = db.Set<TEntity>().Update(obj);
                db.SaveChanges();

                return entity.Entity;
            }
        }
    }
}

