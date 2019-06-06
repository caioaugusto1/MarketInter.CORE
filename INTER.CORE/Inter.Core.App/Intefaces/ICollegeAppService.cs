using Inter.Core.App.ViewModel;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICollegeAppService
    {
        CollegeViewModel Add(int idEnvironment, CollegeViewModel collegeViewModel);

        CollegeViewModel AddCollegeTime(CollegeTimeViewModel collegeTimeViewModel);

        CollegeViewModel GetCollegeTimeByIdCollege(int idCollege);

        CollegeTimeViewModel GetCollegeTimeById(int idCollegeTime);

        List<CollegeViewModel> GetAll(int idEnvironment);

        CollegeViewModel GetById(int id);

        CollegeViewModel Update(CollegeViewModel collegeViewModel);

        CollegeTimeViewModel UpdateCollegeTime(CollegeTimeViewModel collegeTimeViewModel);
    }
}
