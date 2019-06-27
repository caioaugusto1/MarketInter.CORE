using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class PaymentCulturalExchangeService : IPaymentCulturalExchangeService
    {
        private readonly IPaymentCulturalExchangeRepository _paymentCulturalExchangeRepository;

        public PaymentCulturalExchangeService(
            IPaymentCulturalExchangeRepository paymentCulturalExchangeRepository)
        {
            _paymentCulturalExchangeRepository = paymentCulturalExchangeRepository;
        }

        public PaymentCulturalExchange Add(PaymentCulturalExchange payment)
        {
            return _paymentCulturalExchangeRepository.Insert(payment);
        }

        public List<PaymentCulturalExchange> GetAll(Guid idEnvironment)
        {
            return _paymentCulturalExchangeRepository.FindByFilter(x => x.EnvironmentId == idEnvironment);
        }

        public PaymentCulturalExchange GetById(Guid id)
        {
            return _paymentCulturalExchangeRepository.GetById(id);
        }

        public PaymentCulturalExchange Update(Guid idEnvironment, PaymentCulturalExchange payment)
        {
            return _paymentCulturalExchangeRepository.Update(payment);
        }
    }
}
