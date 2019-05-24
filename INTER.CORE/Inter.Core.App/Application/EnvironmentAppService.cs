using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Application
{
    public class EnvironmentAppService : IEnvironmentAppService
    {
        private readonly IEnvironmentService _environmentService;

        public EnvironmentAppService(IEnvironmentService environmentService)
        {
            _environmentService = environmentService;
        }

        public void Add(EnvironmentViewModel environmentVM)
        {
            var environment = Mapper.Map<Inter.Core.Domain.Entities.Environment>(environmentVM);

            _environmentService.Add(environment);
        }

        public List<EnvironmentViewModel> GetAll()
        {
            return Mapper.Map<List<EnvironmentViewModel>>(_environmentService.GetAll());
        }

        public EnvironmentViewModel GetByCode(string code)
        {
            return Mapper.Map<EnvironmentViewModel>(_environmentService.GetByCode(code));
        }

        public EnvironmentViewModel GetById(int id)
        {
            return Mapper.Map<EnvironmentViewModel>(_environmentService.GetById(id));
        }

        public void Update(EnvironmentViewModel environment)
        {
            throw new NotImplementedException();
        }
    }
}
