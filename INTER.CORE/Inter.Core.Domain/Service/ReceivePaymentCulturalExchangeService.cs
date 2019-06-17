using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System;
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
            payment.Id = Guid.NewGuid();
            return _receivePaymentCulturalExchangeRepository.Insert(payment);
        }

        public List<ReceivePaymentCulturalExchange> GetAll(Guid idEnvironment)
        {
            return _receivePaymentCulturalExchangeRepository.FindByFilter(x => x.EnvironmentId == idEnvironment);
        }

        public List<ReceivePaymentCulturalExchange> GetAllByCulturalExchangeId(Guid culturalExchangeId)
        {
            return _receivePaymentCulturalExchangeRepository.GetAllIncludedDependencysByCulturalExchangeId(culturalExchangeId);
        }

        public List<ReceivePaymentCulturalExchange> GetAllIncludedDependency(Guid idEnviroment)
        {
            return _receivePaymentCulturalExchangeRepository.GetAllIncludedDependencys(idEnviroment);
        }

        public ReceivePaymentCulturalExchange GetById(Guid id)
        {
            return _receivePaymentCulturalExchangeRepository.GetByIdIncludedDependency(id);
        }

        public ReceivePaymentCulturalExchange Update(Guid idEnvironment, ReceivePaymentCulturalExchange payment)
        {
            return _receivePaymentCulturalExchangeRepository.Update(payment);
        }
    }
}
