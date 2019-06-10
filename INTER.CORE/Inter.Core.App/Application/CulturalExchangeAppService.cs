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

        public CulturalExchangeAppService(IMapper mapper, ICulturalExchangeService culturalExchangeService, IEnvironmentService environmentService)
        {
            _mapper = mapper;
            _culturalExchangeService = culturalExchangeService;
            _environmentService = environmentService;
        }

        public CulturalExchangeViewModel Add(int idEnvironment, CulturalExchangeViewModel culturalExchangeView)
        {
            var culturalExchange = _mapper.Map<CulturalExchange>(culturalExchangeView);
            culturalExchange.Environment = _mapper.Map<SystemEnvironment>(_environmentService.GetById(idEnvironment));

            return _mapper.Map<CulturalExchangeViewModel>(_culturalExchangeService.Add(culturalExchange));
        }

        public List<CulturalExchangeViewModel> GetAll(int idEnvironment)
        {
            return _mapper.Map<List<CulturalExchangeViewModel>>(_culturalExchangeService.GetAll(idEnvironment));
        }

        public CulturalExchangeViewModel GetById(int id)
        {
            return _mapper.Map<CulturalExchangeViewModel>(_culturalExchangeService.GetById(id));
        }

        public CulturalExchangeViewModel Update(CulturalExchangeViewModel collegeViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
