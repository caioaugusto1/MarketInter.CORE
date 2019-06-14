using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
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

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<ReceivePaymentCulturalExchangeViewModel> GetAll(int environmentId)
        {
            return _mapper.Map<List<ReceivePaymentCulturalExchangeViewModel>>(_receivePaymentCulturalExchangeService.GetAll(environmentId));
        }

        public List<ReceivePaymentCulturalExchangeViewModel> GetAllIncludedDependency(int environmentId)
        {
            return _mapper.Map<List<ReceivePaymentCulturalExchangeViewModel>>(_receivePaymentCulturalExchangeService.GetAllIncludedDependency(environmentId));
        }

        public ReceivePaymentCulturalExchangeViewModel GetById(int id)
        {
            return _mapper.Map<ReceivePaymentCulturalExchangeViewModel>(_receivePaymentCulturalExchangeService.GetById(id));
        }

        public ReceivePaymentCulturalExchangeViewModel Update(int environmentId, ReceivePaymentCulturalExchangeViewModel paymentVM)
        {
            var paymentEntity = _mapper.Map<ReceivePaymentCulturalExchange>(paymentVM);

            return _mapper.Map<ReceivePaymentCulturalExchangeViewModel>(_receivePaymentCulturalExchangeService.Update(environmentId, paymentEntity));
        }
    }
}
