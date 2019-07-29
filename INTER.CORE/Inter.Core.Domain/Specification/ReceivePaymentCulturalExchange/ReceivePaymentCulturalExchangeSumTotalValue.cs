using DomainValidation.Interfaces.Specification;
using Inter.Core.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Inter.Core.Domain.Specification.ReceivePaymentCulturalExchange
{
    public class ReceivePaymentCulturalExchangeSumTotalValue : ISpecification<Entities.ReceivePaymentCulturalExchange>
    {
        private readonly IReceivePaymentCulturalExchangeRepository _receivePaymentCulturalExchangeRepository;
        private readonly ICulturalExchangeRepository _culturalExchangeRepository;

        public ReceivePaymentCulturalExchangeSumTotalValue(
            IReceivePaymentCulturalExchangeRepository receivePaymentCulturalExchangeRepository,
            ICulturalExchangeRepository culturalExchangeRepository)
        {
            _receivePaymentCulturalExchangeRepository = receivePaymentCulturalExchangeRepository;
            _culturalExchangeRepository = culturalExchangeRepository;
        }

        public bool IsSatisfiedBy(Entities.ReceivePaymentCulturalExchange entity)
        {
            var payments = _receivePaymentCulturalExchangeRepository.FindByFilter(x => x.CulturalExchangeId == entity.CulturalExchangeId);
            var culturalExchange = _culturalExchangeRepository.GetById(entity.CulturalExchangeId);

            var sumTotalPayments = payments.Sum(x => x.Value);

            var sumTotalIncludedNewPayment = sumTotalPayments + entity.Value;

            if (sumTotalIncludedNewPayment > culturalExchange.TotalValue)
                entity.ValidationResult.Add(new ValidationResult("Values incorrects"));

            return true;
        }
    }
}
