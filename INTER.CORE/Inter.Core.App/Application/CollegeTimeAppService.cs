using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Application
{
    public class CollegeTimeAppService : ICollegeTimeAppService
    {
        private readonly IMapper _mapper;
        private readonly ICollegeTimeService _collegeService;

        public CollegeTimeAppService(
            IMapper mapper,
            ICollegeTimeService collegeService)
        {
            _mapper = mapper;
            _collegeService = collegeService;
        }

        public CollegeTimeViewModel Add(CollegeTimeViewModel collegeTimeVM)
        {
            var collegeEntity = _mapper.Map<CollegeTime>(collegeTimeVM);
            return _mapper.Map<CollegeTimeViewModel>(_collegeService.Add(collegeEntity));
        }

        public void Delete(Guid id)
        {
            var entity = _mapper.Map<CollegeTime>(_collegeService.GetById(id));

            _collegeService.Delete(entity);
        }

        public List<CollegeTimeViewModel> GetAllByCollegeId(Guid idCollege)
        {
            return _mapper.Map<List<CollegeTimeViewModel>>(_collegeService.GetAll(idCollege));
        }

        public CollegeTimeViewModel GetById(Guid id)
        {
            return _mapper.Map<CollegeTimeViewModel>(_collegeService.GetById(id));
        }

        public CollegeTimeViewModel Update(CollegeTimeViewModel collegeTimeVM)
        {
            var collegeEntity = _mapper.Map<CollegeTime>(collegeTimeVM);

            return _mapper.Map<CollegeTimeViewModel>(_collegeService.Update(collegeEntity));
        }
    }
}
