using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
using System.Collections.Generic;
using static Inter.Core.Domain.Entities.College;

namespace Inter.Core.App.Application
{
    public class CollegeAppService : ICollegeAppService
    {
        private readonly IMapper _mapper;
        private readonly ICollegeService _collegeService;
        private readonly IEnvironmentService _environmentService;

        public CollegeAppService(IMapper mapper, ICollegeService collegeService, IEnvironmentService environmentService)
        {
            _collegeService = collegeService;
            _mapper = mapper;
            _environmentService = environmentService;
        }

        public CollegeViewModel Add(int idEnvironment, CollegeViewModel collegeViewModel)
        {
            var college = _mapper.Map<College>(collegeViewModel);
            var environment = _mapper.Map<SystemEnvironment>(_environmentService.GetById(idEnvironment));

            return _mapper.Map<CollegeViewModel>(_collegeService.Add(environment, college));
        }

        public CollegeViewModel AddCollegeTime(CollegeTimeViewModel collegeTimeViewModel)
        {
            var college = _mapper.Map<College>(_collegeService.GetById(collegeTimeViewModel.CollegeId));
            var collegeTime = _mapper.Map<CollegeTime>(collegeTimeViewModel);

            college.TimeCollege.Add(collegeTime);

            return _mapper.Map<CollegeViewModel>(_collegeService.Update(college));
        }

        public List<CollegeViewModel> GetAll(int idEnvironment)
        {
            return _mapper.Map<List<CollegeViewModel>>(_collegeService.GetAll(idEnvironment));
        }

        public CollegeViewModel GetById(int id)
        {
            return _mapper.Map<CollegeViewModel>(_collegeService.GetById(id));
        }

        public CollegeTimeViewModel GetCollegeTimeById(int idCollegeTime)
        {
            return _mapper.Map<CollegeTimeViewModel>(_collegeService.GetCollegeTimeById(idCollegeTime));
        }

        public CollegeViewModel GetCollegeTimeByIdCollege(int idCollege)
        {
            return _mapper.Map<CollegeViewModel>(_collegeService.GetCollegeTimeByCollegeId(idCollege));
        }

        public CollegeViewModel Update(CollegeViewModel collegeViewModel)
        {
            var college = _mapper.Map<College>(collegeViewModel);
            return _mapper.Map<CollegeViewModel>(_collegeService.Update(college));
        }

        public CollegeTimeViewModel UpdateCollegeTime(CollegeTimeViewModel collegeTimeViewModel)
        {
            var collegeTime = _mapper.Map<CollegeTime>(collegeTimeViewModel);
            return _mapper.Map<CollegeTimeViewModel>(_collegeService.UpdateCollegeTime(collegeTime));
        }
    }
}
