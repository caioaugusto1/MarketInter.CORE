using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICollegeAppService
    {
        CollegeViewModel Add(Guid idEnvironment, CollegeViewModel collegeViewModel);

        List<CollegeViewModel> GetAll(Guid idEnvironment);

        CollegeViewModel GetById(Guid id);

        CollegeViewModel Update(CollegeViewModel collegeViewModel);

    }
}
