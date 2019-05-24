using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.ServiceInterface;
using System.Collections.Generic;

namespace Inter.Core.App.Application
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public StudentAppService(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public StudentViewModel Add(StudentViewModel studentViewModel)
        {
            var student = _mapper.Map<Student>(studentViewModel);
            return _mapper.Map<StudentViewModel>(_studentService.Add(student));

        }

        public List<StudentViewModel> GetAll()
        {
            return _mapper.Map<List<StudentViewModel>>(_studentService.GetAll());
        }

        public StudentViewModel GetById(int id)
        {
            return _mapper.Map<StudentViewModel>(_studentService.GetById(id));
        }

        public StudentViewModel Update(StudentViewModel studentViewModel)
        {
            var student = _mapper.Map<Student>(studentViewModel);
            return _mapper.Map<StudentViewModel>(_studentService.Update(student));
        }
    }
}
