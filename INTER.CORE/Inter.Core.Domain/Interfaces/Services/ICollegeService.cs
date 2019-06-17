using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICollegeService
    {
        List<College> GetAll(Guid idEnvironment);

        College Add(SystemEnvironment environment, College college);

        College GetById(Guid id);
        
        College Update(College college);

    }
}
