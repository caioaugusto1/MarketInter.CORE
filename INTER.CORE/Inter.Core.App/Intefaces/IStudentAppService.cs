using Inter.Core.App.ViewModel;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface IStudentAppService
    {
        StudentViewModel Add(int idEnvironment, StudentViewModel studentViewModel);

        List<StudentViewModel> GetAll(int idEnvironment);

        StudentViewModel GetById(int idEnvironment, int id);

        StudentViewModel Update(int idEnvironment, StudentViewModel studentViewModel);
    }
}
