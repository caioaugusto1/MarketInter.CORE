using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICollegeTimeAppService
    {
        CollegeTimeViewModel Add(CollegeTimeViewModel collegeTimeVM);

        CollegeTimeViewModel GetById(Guid id);
        
        CollegeTimeViewModel Update(CollegeTimeViewModel collegeTimeVM);

        void Delete(Guid id);

        List<CollegeTimeViewModel> GetAllByCollegeId(Guid collegeId);
    }
}
