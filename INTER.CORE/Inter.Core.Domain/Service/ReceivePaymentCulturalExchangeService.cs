using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class ReceivePaymentCulturalExchangeService : IReceivePaymentCulturalExchangeService
    {
        private readonly IReceivePaymentCulturalExchangeRepository _receivePaymentCulturalExchangeRepository;

        public ReceivePaymentCulturalExchangeService(IReceivePaymentCulturalExchangeRepository receivePaymentCulturalExchangeRepository)
        {
            _receivePaymentCulturalExchangeRepository = receivePaymentCulturalExchangeRepository;
        }

        public ReceivePaymentCulturalExchange Add(ReceivePaymentCulturalExchange payment)
        {
            return _receivePaymentCulturalExchangeRepository.Insert(payment);
        }

        public List<ReceivePaymentCulturalExchange> GetAll(int idEnvironment)
        {
            return _receivePaymentCulturalExchangeRepository.FindByFilter(x => x.EnvironmentId == idEnvironment);
        }

        public List<ReceivePaymentCulturalExchange> GetAllIncludedDependency(int idEnviroment)
        {
            return _receivePaymentCulturalExchangeRepository.GetAllIncludedDependencys(idEnviroment);
        }

        public ReceivePaymentCulturalExchange GetById(int id)
        {
            return _receivePaymentCulturalExchangeRepository.GetById(id);
        }

        public ReceivePaymentCulturalExchange Update(int idEnvironment, ReceivePaymentCulturalExchange payment)
        {
            return _receivePaymentCulturalExchangeRepository.Update(payment);
        }
    }
}
