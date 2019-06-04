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
        private readonly ICollegeRepository _collegeRepository;

        public CulturalExchangeService(ICulturalExchangeRepository culturalExchangeRepository, ICollegeRepository collegeRepository)
        {
            _culturalExchangeRepository = culturalExchangeRepository;
            _collegeRepository = collegeRepository;
        }

        public CulturalExchange Add(CulturalExchange culturalExchange)
        {
            College college = _collegeRepository.GetById(culturalExchange.College.Id);

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
