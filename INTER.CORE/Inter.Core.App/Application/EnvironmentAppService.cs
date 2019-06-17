using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Application
{
    public class EnvironmentAppService : IEnvironmentAppService
    {
        private readonly IMapper _mapper;
        private readonly IEnvironmentService _environmentService;

        public EnvironmentAppService(IEnvironmentService environmentService, IMapper mapper)
        {
            _environmentService = environmentService;
            _mapper = mapper;
        }

        public void Add(EnvironmentViewModel environmentVM)
        {
            var environment = Mapper.Map<SystemEnvironment>(environmentVM);

            _environmentService.Add(environment);
        }

        public List<EnvironmentViewModel> GetAll()
        {
            return _mapper.Map<List<EnvironmentViewModel>>(_environmentService.GetAll());
        }

        public EnvironmentViewModel GetByCode(string code)
        {
            var environment = _environmentService.GetByCode(code);

            return _mapper.Map<EnvironmentViewModel>(environment);
        }

        public EnvironmentViewModel GetById(Guid id)
        {
            return _mapper.Map<EnvironmentViewModel>(_environmentService.GetById(id));
        }

        public void Update(EnvironmentViewModel environmentVM)
        {
            var environment = Mapper.Map<SystemEnvironment>(environmentVM);

            _environmentService.Update(environment);
        }
    }
}
