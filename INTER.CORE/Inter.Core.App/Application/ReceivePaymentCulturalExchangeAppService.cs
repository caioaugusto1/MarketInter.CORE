using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Application
{
    public class ReceivePaymentCulturalExchangeAppService : IReceivePaymentCulturalExchangeAppService
    {
        private readonly IMapper _mapper;
        private readonly IReceivePaymentCulturalExchangeService _receivePaymentCulturalExchangeService;

        public ReceivePaymentCulturalExchangeAppService(
            IReceivePaymentCulturalExchangeService receivePaymentCulturalExchangeService,
            IMapper mapper)
        {
            _mapper = mapper;
            _receivePaymentCulturalExchangeService = receivePaymentCulturalExchangeService;
        }

        public ReceivePaymentCulturalExchangeViewModel Add(ReceivePaymentCulturalExchangeViewModel paymentVM)
        {
            var paymentEntity = _mapper.Map<ReceivePaymentCulturalExchange>(paymentVM);

            return _mapper.Map<ReceivePaymentCulturalExchangeViewModel>(_receivePaymentCulturalExchangeService.Add(paymentEntity));
        }

        public void Delete(Guid id)
        {
            _mapper.Map<ReceivePaymentCulturalExchangeViewModel>(_receivePaymentCulturalExchangeService.GetById(id));
        }

        public List<ReceivePaymentCulturalExchangeViewModel> GetAll(Guid environmentId)
        {
            return _mapper.Map<List<ReceivePaymentCulturalExchangeViewModel>>(_receivePaymentCulturalExchangeService.GetAll(environmentId));
        }

        public List<ReceivePaymentCulturalExchangeViewModel> GetAllIncludedDependency(Guid environmentId)
        {
            return _mapper.Map<List<ReceivePaymentCulturalExchangeViewModel>>(_receivePaymentCulturalExchangeService.GetAllIncludedDependency(environmentId));
        }

        public List<ReceivePaymentCulturalExchangeViewModel> GetByCulturalExchangeId(Guid culturalExchangeId)
        {
            return _mapper.Map<List<ReceivePaymentCulturalExchangeViewModel>>(_receivePaymentCulturalExchangeService.GetAllByCulturalExchangeId(culturalExchangeId));
        }

        public ReceivePaymentCulturalExchangeViewModel GetById(Guid id)
        {
            return _mapper.Map<ReceivePaymentCulturalExchangeViewModel>(_receivePaymentCulturalExchangeService.GetById(id));
        }

        public ReceivePaymentCulturalExchangeViewModel Update(Guid environmentId, ReceivePaymentCulturalExchangeViewModel paymentVM)
        {
            var paymentEntity = _mapper.Map<ReceivePaymentCulturalExchange>(paymentVM);

            return _mapper.Map<ReceivePaymentCulturalExchangeViewModel>(_receivePaymentCulturalExchangeService.Update(environmentId, paymentEntity));
        }
    }
}
