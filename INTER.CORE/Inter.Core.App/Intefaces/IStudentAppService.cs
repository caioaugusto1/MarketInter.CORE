using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface IStudentAppService
    {
        StudentViewModel Add(Guid idEnvironment, StudentViewModel studentViewModel);

        List<StudentViewModel> GetAll(Guid idEnvironment);

        List<StudentViewModel> GetStudentsNotEnroled(Guid idEnvironment);

        StudentViewModel GetById(Guid idEnvironment, Guid id);

        StudentViewModel Update(Guid idEnvironment, StudentViewModel studentViewModel);

        void Delete(Guid id);
    }
}
