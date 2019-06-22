using Inter.Core.Domain.Entities;

namespace Inter.Core.Domain.Interfaces.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        bool ValidationCustomerId(string customerId);
    }
}
