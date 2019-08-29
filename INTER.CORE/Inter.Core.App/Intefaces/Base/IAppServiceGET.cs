using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.App.Intefaces.Base
{
    public interface IAppServiceGET<VMEntity> where VMEntity : class
    {
        Task<List<VMEntity>> GetAll(Guid idEnvironment);

        VMEntity GetById(Guid id);
    }
}
