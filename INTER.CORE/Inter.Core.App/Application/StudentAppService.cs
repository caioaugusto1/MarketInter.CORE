using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.ServiceInterface;

namespace Inter.Core.App.Application
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentService _studentService;

        public StudentAppService(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public StudentViewModel Add(StudentViewModel studentViewModel)
        {
            var e = new Student();

            _studentService.Add(e);


            throw new System.NotImplementedException();
        }
    }
}
