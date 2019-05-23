using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Presentation.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.Infra.Data.Repositories
{
    public class RepositoryBase <TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        
        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Dispose()
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
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}

