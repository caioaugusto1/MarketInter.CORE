﻿using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Presentation.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Inter.Core.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<TEntity> DbSet;
        private readonly DbContextOptions<Inter.Core.Infra.Data.Context.Context> _OptionsBuilder;


        //private readonly DbContextOptions<ApplicationDbContext> _OptionsBuilder;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;

            _OptionsBuilder = new DbContextOptions<Inter.Core.Infra.Data.Context.Context>();
            //_OptionsBuilder = new DbContextOptions<ApplicationDbContext>();
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
            using (var db = new Inter.Core.Infra.Data.Context.Context(_OptionsBuilder))
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
