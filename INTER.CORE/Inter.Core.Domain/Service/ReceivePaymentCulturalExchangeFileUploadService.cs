using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class ReceivePaymentCulturalExchangeFileUploadService : IReceivePaymentCulturalExchangeFileUploadService
    {
        private readonly IReceivePaymentCulturalExchangeFileUploadRepository _receivePaymentCulturalExchangeFileUploadRepository;

        public ReceivePaymentCulturalExchangeFileUploadService(IReceivePaymentCulturalExchangeFileUploadRepository receivePaymentCulturalExchangeFileUploadRepository)
        {
            _receivePaymentCulturalExchangeFileUploadRepository = receivePaymentCulturalExchangeFileUploadRepository;
        }

        public ReceivePaymentCulturalExchangeFileUpload Add(ReceivePaymentCulturalExchangeFileUpload file)
        {
            return _receivePaymentCulturalExchangeFileUploadRepository.Insert(file);
        }

        public void Delete(Guid id)
        {
            //return _receivePaymentCulturalExchangeFileUploadRepository.Delete(id);
        }

        public List<ReceivePaymentCulturalExchangeFileUpload> GetAll(Guid environmentId)
        {
            return _receivePaymentCulturalExchangeFileUploadRepository.GetAll();
        }

        public ReceivePaymentCulturalExchangeFileUpload GetById(Guid id)
        {
            return _receivePaymentCulturalExchangeFileUploadRepository.GetById(id);
        }

        public ReceivePaymentCulturalExchangeFileUpload Update(ReceivePaymentCulturalExchangeFileUpload file)
        {
            return _receivePaymentCulturalExchangeFileUploadRepository.Update(file);
        }
    }
}
