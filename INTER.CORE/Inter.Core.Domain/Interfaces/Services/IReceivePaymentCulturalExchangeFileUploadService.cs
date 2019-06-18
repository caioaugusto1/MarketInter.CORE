using Inter.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IReceivePaymentCulturalExchangeFileUploadService
    {
        ReceivePaymentCulturalExchangeFileUpload Add(ReceivePaymentCulturalExchangeFileUpload file);

        List<ReceivePaymentCulturalExchangeFileUpload> GetAll(Guid environmentId);

        ReceivePaymentCulturalExchangeFileUpload GetById(Guid id);

        ReceivePaymentCulturalExchangeFileUpload Update(ReceivePaymentCulturalExchangeFileUpload file);

        void Delete(Guid id);
    }
}
