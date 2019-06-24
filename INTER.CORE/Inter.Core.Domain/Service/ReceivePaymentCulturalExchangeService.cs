using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using Inter.Core.Domain.Specification.ReceivePaymentCulturalExchange;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inter.Core.Domain.Service
{
    public class ReceivePaymentCulturalExchangeService : IReceivePaymentCulturalExchangeService
    {
        private readonly IReceivePaymentCulturalExchangeRepository _receivePaymentCulturalExchangeRepository;
        private readonly ICulturalExchangeRepository _culturalExchangeRepository;

        public ReceivePaymentCulturalExchangeService(
            IReceivePaymentCulturalExchangeRepository receivePaymentCulturalExchangeRepository,
            ICulturalExchangeRepository culturalExchangeRepository)
        {
            _culturalExchangeRepository = culturalExchangeRepository;
            _receivePaymentCulturalExchangeRepository = receivePaymentCulturalExchangeRepository;
        }

        public ReceivePaymentCulturalExchange Add(ReceivePaymentCulturalExchange payment)
        {
            payment.Id = Guid.NewGuid();
            payment.UploadDate = DateTime.Now;

            bool validationValue = new ReceivePaymentCulturalExchangeSumTotalValue(_receivePaymentCulturalExchangeRepository, _culturalExchangeRepository).IsSatisfiedBy(payment);

            if (!payment.ValidationResult.Any())
            {
                _receivePaymentCulturalExchangeRepository.Insert(payment);

                bool setFlagPaid = new ReceivePaymentCulturalExchangeSetFlagPaid(_receivePaymentCulturalExchangeRepository, _culturalExchangeRepository).IsSatisfiedBy(payment);
                if (setFlagPaid)
                {
                    //var culturalExchange = _culturalExchangeRepository.GetById(payment.CulturalExchangeId);
                    //culturalExchange.CollegePayment = true;
                    //_culturalExchangeRepository.Update(culturalExchange);
                }
            }

            return payment;
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
