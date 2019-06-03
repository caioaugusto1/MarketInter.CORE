using Inter.Core.App.ViewModel;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICollegeAppService
    {
        CollegeViewModel Add(CollegeViewModel collegeViewModel, List<CollegeTimeViewModel> collegeTimeViewModel);

        List<CollegeViewModel> GetAll();

        CollegeViewModel GetById(int id);

        CollegeViewModel Update(CollegeViewModel collegeViewModel);
    }
}
