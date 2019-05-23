using Inter.Core.App.ViewModel;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface IStudentAppService
    {
        StudentViewModel Add(StudentViewModel studentViewModel);

        List<StudentViewModel> GetAll();

        StudentViewModel GetById(int id);

        StudentViewModel Update(StudentViewModel studentViewModel);
    }
}
