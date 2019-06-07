using Inter.Core.App.ViewModel;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICollegeAppService
    {
        CollegeViewModel Add(int idEnvironment, CollegeViewModel collegeViewModel);

        List<CollegeViewModel> GetAll(int idEnvironment);

        CollegeViewModel GetById(int id);

        CollegeViewModel Update(CollegeViewModel collegeViewModel);

    }
}
