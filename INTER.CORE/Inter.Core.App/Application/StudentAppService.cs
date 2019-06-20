using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Application
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly IEnvironmentService _environmentService;

        public StudentAppService(IMapper mapper, IStudentService studentService, IEnvironmentService environmentService)
        {
            _mapper = mapper;
            _studentService = studentService;
            _environmentService = environmentService;
        }

        public StudentViewModel Add(Guid idEnvironment, StudentViewModel studentViewModel)
        {
            Student student = _mapper.Map<Student>(studentViewModel);
            SystemEnvironment environment = _mapper.Map<SystemEnvironment>(_environmentService.GetById(idEnvironment));

            return _mapper.Map<StudentViewModel>(_studentService.Add(environment, student));

        }

        public void Delete(Guid id)
        {
            _studentService.Delete(id);
        }

        public List<StudentViewModel> GetAll(Guid idEnvironment)
        {
            return _mapper.Map<List<StudentViewModel>>(_studentService.GetAll(idEnvironment));
        }

        public StudentViewModel GetById(Guid idEnvironment, Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentService.GetById(idEnvironment, id));
        }

        public List<StudentViewModel> GetStudentsNotEnroled(Guid idEnvironment)
        {
            return _mapper.Map<List<StudentViewModel>>(_studentService.GetNotEnroled(idEnvironment));
        }

        public StudentViewModel Update(Guid idEnvironment, StudentViewModel studentViewModel)
        {
            Student student = _mapper.Map<Student>(studentViewModel);
            return _mapper.Map<StudentViewModel>(_studentService.Update(idEnvironment, student));
        }
    }
}
