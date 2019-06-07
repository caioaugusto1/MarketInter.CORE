using Inter.Core.App.ViewModel;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICollegeTimeAppService
    {
        CollegeTimeViewModel Add(CollegeTimeViewModel collegeTimeVM);

        CollegeTimeViewModel GetById(int id);
        
        CollegeTimeViewModel Update(CollegeTimeViewModel collegeTimeVM);

        List<CollegeTimeViewModel> GetAllByCollegeId(int collegeId);
    }
}
