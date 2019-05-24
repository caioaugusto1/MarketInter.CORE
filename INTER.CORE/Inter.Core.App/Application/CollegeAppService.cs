﻿using System.Collections.Generic;
using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;

namespace Inter.Core.App.Application
{
    public class CollegeAppService : ICollegeAppService
    {
        private readonly IMapper _mapper;
        private readonly ICollegeService _collegeService;

        public CollegeAppService(ICollegeService collegeService, IMapper mapper)
        {
            _collegeService = collegeService;
            _mapper = mapper;
        }

        public CollegeViewModel Add(CollegeViewModel collegeViewModel)
        {
            var college = _mapper.Map<College>(collegeViewModel);
            return _mapper.Map<CollegeViewModel>(_collegeService.Add(college));
        }

        public List<CollegeViewModel> GetAll()
        {
            return _mapper.Map<List<CollegeViewModel>>(_collegeService.GetAll());
        }

        public CollegeViewModel GetById(int id)
        {
            return _mapper.Map<CollegeViewModel>(_collegeService.GetById(id));
        }

        public CollegeViewModel Update(CollegeViewModel collegeViewModel)
        {
            var college = _mapper.Map<College>(collegeViewModel);
            return _mapper.Map<CollegeViewModel>(_collegeService.Update(college));
        }
    }
}