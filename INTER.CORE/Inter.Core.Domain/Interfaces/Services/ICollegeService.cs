using Inter.Core.Domain.Entities;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICollegeService
    {
        College Add(College college);

        List<College> GetAll(int idEnvironment);

        College GetById(int id);

        College GetCollegeTimeByCollegeId(int id);

        College Update(College college);
    }
}
