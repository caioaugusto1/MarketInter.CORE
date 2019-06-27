using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Application
{
    public class PaymentCulturalExchangeAppService : IPaymentCulturalExchangeAppService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentCulturalExchangeService _paymentCulturalExchangeService;

        public PaymentCulturalExchangeAppService(
            IMapper mapper,
            IPaymentCulturalExchangeService paymentCulturalExchangeService)
        {
            _mapper = mapper;
            _paymentCulturalExchangeService = paymentCulturalExchangeService;
        }

        public PaymentCulturalExchangeViewModel Add(PaymentCulturalExchangeViewModel paymentVM)
        {
            var entity = _mapper.Map<PaymentCulturalExchange>(paymentVM);

            return _mapper.Map<PaymentCulturalExchangeViewModel>(_paymentCulturalExchangeService.Add(entity));
        }

        public List<PaymentCulturalExchangeViewModel> GetAll(Guid idEnvironment)
        {
            return _mapper.Map<List<PaymentCulturalExchangeViewModel>>(_paymentCulturalExchangeService.GetAll(idEnvironment));
        }

        public PaymentCulturalExchangeViewModel GetById(Guid id)
        {
            return _mapper.Map<PaymentCulturalExchangeViewModel>(_paymentCulturalExchangeService.GetById(id));
        }

        public PaymentCulturalExchangeViewModel Update(Guid idEnvironment, PaymentCulturalExchangeViewModel paymentVM)
        {
            var entity = _mapper.Map<PaymentCulturalExchange>(paymentVM);

            return _mapper.Map<PaymentCulturalExchangeViewModel>(_paymentCulturalExchangeService.Update(idEnvironment, entity));
        }
    }
}
