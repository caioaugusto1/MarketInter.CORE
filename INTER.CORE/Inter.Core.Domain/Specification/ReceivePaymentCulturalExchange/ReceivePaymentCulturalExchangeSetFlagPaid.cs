using DomainValidation.Interfaces.Specification;
using Inter.Core.Domain.Interfaces.Repositories;
using System.Linq;

namespace Inter.Core.Domain.Specification.ReceivePaymentCulturalExchange
{
    public class ReceivePaymentCulturalExchangeSetFlagPaid : ISpecification<Entities.ReceivePaymentCulturalExchange>
    {
        private readonly IReceivePaymentCulturalExchangeRepository _receivePaymentCulturalExchangeRepository;
        private readonly ICulturalExchangeRepository _culturalExchangeRepository;

        public ReceivePaymentCulturalExchangeSetFlagPaid(
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

            var lastTotalPayments = payments.Sum(x => x.Value) - culturalExchange.TotalValue;

            if (lastTotalPayments == 0)
                return true;

            return false;
        }
    }
}
