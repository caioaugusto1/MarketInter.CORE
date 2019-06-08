using Inter.Core.Domain.Entities;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IStudentFileUploadService
    {
        StudentFileUpload Add(StudentFileUpload file);

        List<StudentFileUpload> GetAllByStudentId(int studentId);

        StudentFileUpload GetById(int id);

        StudentFileUpload Update(StudentFileUpload file);

        void Delete(int id);
    }
}
