using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Application
{
    public class CulturalExchangeAppService : ICulturalExchangeAppService
    {
        private readonly IMapper _mapper;
        private readonly ICulturalExchangeService _culturalExchangeService;
        private readonly IEnvironmentService _environmentService;

        public CulturalExchangeAppService(ICulturalExchangeService culturalExchangeService)
        {

        }

        public CulturalExchangeViewModel Add(int idEnvironment, CulturalExchangeViewModel culturalExchangeView)
        {
            var culturalExchange = _mapper.Map<CulturalExchange>(culturalExchangeView);
            var environment = _mapper.Map<SystemEnvironment>(_environmentService.GetById(idEnvironment));

            return _mapper.Map<CulturalExchangeViewModel>(_culturalExchangeService.Add(environment, culturalExchange));
        }

        public List<CulturalExchangeViewModel> GetAll(int idEnvironment)
        {
            return _mapper.Map<List<CulturalExchangeViewModel>>(_culturalExchangeService.GetAll(idEnvironment));
        }

        public CulturalExchangeViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CulturalExchangeViewModel Update(CulturalExchangeViewModel collegeViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
