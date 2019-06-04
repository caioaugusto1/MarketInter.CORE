using Inter.Core.App.ViewModel;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICollegeAppService
    {
        CollegeViewModel Add(CollegeViewModel collegeViewModel);

        CollegeViewModel AddCollegeTime(CollegeTimeViewModel collegeTimeViewModel);

        CollegeViewModel GetCollegeTimeByIdCollege(int idCollege);

        List<CollegeViewModel> GetAll();

        CollegeViewModel GetById(int id);

        CollegeViewModel Update(CollegeViewModel collegeViewModel);
    }
}
