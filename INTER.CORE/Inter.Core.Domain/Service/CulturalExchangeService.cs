using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Inter.Core.Domain.Service
{
    public class CulturalExchangeService : ICulturalExchangeService
    {
        private readonly ICulturalExchangeRepository _culturalExchangeRepository;

        public CulturalExchangeService(ICulturalExchangeRepository culturalExchangeRepository)
        {
            _culturalExchangeRepository = culturalExchangeRepository;
        }

        public CulturalExchange Add(SystemEnvironment environment, CulturalExchange culturalExchange)
        {
            return _culturalExchangeRepository.Insert(culturalExchange);
        }

        public List<CulturalExchange> GetAll(int idEnvironment)
        {
            return _culturalExchangeRepository.GetAll().Where(x => x.Environment.Id == idEnvironment).ToList();
        }

        public CulturalExchange GetById(int idEnvironment, int id)
        {
            throw new System.NotImplementedException();
        }

        public CulturalExchange Update(int idEnvironment, CulturalExchange student)
        {
            throw new System.NotImplementedException();
        }
    }
}
