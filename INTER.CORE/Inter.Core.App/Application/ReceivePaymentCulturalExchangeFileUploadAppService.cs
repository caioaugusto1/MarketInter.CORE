using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Application
{
    public class ReceivePaymentCulturalExchangeFileUploadAppService : IReceivePaymentCulturalExchangeFileUploadAppService
    {
        private readonly IMapper _mapper;
        private readonly IReceivePaymentCulturalExchangeFileUploadService _receivePaymentCulturalExchangeFileUploadService;

        public ReceivePaymentCulturalExchangeFileUploadAppService(
            IMapper mapper,
            IReceivePaymentCulturalExchangeFileUploadService receivePaymentCulturalExchangeFileUploadService)
        {
            _mapper = mapper;
            _receivePaymentCulturalExchangeFileUploadService = receivePaymentCulturalExchangeFileUploadService;
        }

        public ReceivePaymentCulturalExchangeFileUploadViewModel Add(ReceivePaymentCulturalExchangeFileUploadViewModel paymentVM)
        {
            var receivePaymentEntity = _mapper.Map<ReceivePaymentCulturalExchangeFileUpload>(paymentVM);

            return _mapper.Map<ReceivePaymentCulturalExchangeFileUploadViewModel>(_receivePaymentCulturalExchangeFileUploadService.Add(receivePaymentEntity));
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ReceivePaymentCulturalExchangeFileUploadViewModel> GetAll(Guid environmentId)
        {
            return _mapper.Map<List<ReceivePaymentCulturalExchangeFileUploadViewModel>>(_receivePaymentCulturalExchangeFileUploadService.GetAll(environmentId));
        }

        public ReceivePaymentCulturalExchangeFileUploadViewModel GetById(Guid id)
        {
            return _mapper.Map<ReceivePaymentCulturalExchangeFileUploadViewModel>(_receivePaymentCulturalExchangeFileUploadService.GetById(id));
        }

        public ReceivePaymentCulturalExchangeFileUploadViewModel Update(Guid environmentId, ReceivePaymentCulturalExchangeFileUploadViewModel paymentVM)
        {
            var receivePaymentEntity = _mapper.Map<ReceivePaymentCulturalExchangeFileUpload>(paymentVM);

            return _mapper.Map<ReceivePaymentCulturalExchangeFileUploadViewModel>(_receivePaymentCulturalExchangeFileUploadService.Update(receivePaymentEntity));
        }
    }
}
