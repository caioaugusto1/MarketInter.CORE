using System.Collections.Generic;
using AutoMapper;
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
            var student = Mapper.Map<Student>(studentViewModel);
            
            _studentService.Add(student);
            
            throw new System.NotImplementedException();
        }

        public List<StudentViewModel> GetAll()
        {
            return Mapper.Map<List<StudentViewModel>>(_studentService.GetAll());
        }

        public StudentViewModel GetById(int id)
        {
            return Mapper.Map<StudentViewModel>(_studentService.GetAll());
        }

        public StudentViewModel Update(StudentViewModel studentViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
