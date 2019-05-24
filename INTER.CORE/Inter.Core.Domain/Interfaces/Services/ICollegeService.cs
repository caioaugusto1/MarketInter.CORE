using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface ICollegeService
    {
        College Add(College college);

        List<College> GetAll();

        College GetById(int id);

        College Update(College college);
    }
}
