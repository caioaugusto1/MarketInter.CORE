using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class StudentFileUploadService : IStudentFileUploadService
    {
        private readonly IStudentFileUploadRepository _studentFileUploadRepository;

        public StudentFileUploadService(IStudentFileUploadRepository studentFileUploadRepository)
        {
            _studentFileUploadRepository = studentFileUploadRepository;
        }

        public StudentFileUpload Add(StudentFileUpload file)
        {
            return _studentFileUploadRepository.Insert(file);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<StudentFileUpload> GetAllByStudentId(int studentId)
        {
            return _studentFileUploadRepository.FindByFilter(x => x.StudentId == studentId);
        }

        public StudentFileUpload GetById(int id)
        {
            return _studentFileUploadRepository.GetById(id);
        }

        public StudentFileUpload Update(StudentFileUpload file)
        {
            return _studentFileUploadRepository.Update(file);
        }
    }
}
