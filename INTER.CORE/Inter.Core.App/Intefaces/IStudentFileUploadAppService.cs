using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.App.Intefaces
{
    public interface IStudentFileUploadAppService
    {
        StudentFileUploadViewModel Add(StudentFileUploadViewModel file);

        List<StudentFileUploadViewModel> GetAllByStudentId(int studentId);

        StudentFileUploadViewModel GetById(int id);

        StudentFileUploadViewModel Update(StudentFileUploadViewModel file);

        void Delete(int id);
    }
}
