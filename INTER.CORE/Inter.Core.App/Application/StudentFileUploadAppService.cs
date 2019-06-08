using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Application
{
    public class StudentFileUploadAppService : IStudentFileUploadAppService
    {
        private readonly IMapper _mapper;
        private readonly IStudentFileUploadService _studentFileUploadService;

        public StudentFileUploadAppService(IMapper mapper, IStudentFileUploadService studentFileUploadService)
        {
            _mapper = mapper;
            _studentFileUploadService = studentFileUploadService;
        }

        public StudentFileUploadViewModel Add(StudentFileUploadViewModel file)
        {
            var studentEntity = _mapper.Map<StudentFileUpload>(file);

            return _mapper.Map<StudentFileUploadViewModel>(_studentFileUploadService.Add(studentEntity));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentFileUploadViewModel> GetAllByStudentId(int studentId)
        {
            return _mapper.Map<List<StudentFileUploadViewModel>>(_studentFileUploadService.GetAllByStudentId(studentId));
        }

        public StudentFileUploadViewModel GetById(int id)
        {
            return _mapper.Map<StudentFileUploadViewModel>(_studentFileUploadService.GetById(id));
        }

        public StudentFileUploadViewModel Update(StudentFileUploadViewModel file)
        {
            var studentEntity = _mapper.Map<StudentFileUpload>(file);

            return _mapper.Map<StudentFileUploadViewModel>(_studentFileUploadService.Update(studentEntity));
        }
    }
}
