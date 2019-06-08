using Inter.Core.Domain.Entities;
using System.Collections.Generic;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IStudentFileUploadRepository : IRepository<StudentFileUpload>
    {
        List<StudentFileUpload> GetAllByStudentId(int studentId);
    }
}
