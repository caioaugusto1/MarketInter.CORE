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

        public CollegeViewModel AddCollegeTime(CollegeTimeViewModel collegeTimeViewModel)
        {
            var college = _mapper.Map<College>(_collegeService.GetById(collegeTimeViewModel.CollegeId));
            var collegeTime = _mapper.Map<CollegeTime>(collegeTimeViewModel);

            college.TimeCollege.Add(collegeTime);

            return _mapper.Map<CollegeViewModel>(_collegeService.Update(college));
        }

        public List<CollegeViewModel> GetAll()
        {
            return _mapper.Map<List<CollegeViewModel>>(_collegeService.GetAll());
        }

        public CollegeViewModel GetById(int id)
        {
            return _mapper.Map<CollegeViewModel>(_collegeService.GetById(id));
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
    }
}
