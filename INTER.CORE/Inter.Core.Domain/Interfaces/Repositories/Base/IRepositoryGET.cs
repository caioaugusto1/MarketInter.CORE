using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryGET<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllByDapper(Guid idEnvironment);
    }
}
