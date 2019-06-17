using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IEnvironmentService
    {
        void Add(SystemEnvironment environment);

        List<SystemEnvironment> GetAll();

        SystemEnvironment GetById(Guid id);

        SystemEnvironment GetByCode(string code);

        SystemEnvironment GetStudentsNotEnroled(Guid idEnvironment);

        void Update(SystemEnvironment environment);
    }
}
