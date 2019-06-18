using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.App.Intefaces
{
    public interface IReceivePaymentCulturalExchangeFileUploadAppService
    {
        ReceivePaymentCulturalExchangeFileUploadViewModel Add(ReceivePaymentCulturalExchangeFileUploadViewModel paymentVM);

        List<ReceivePaymentCulturalExchangeFileUploadViewModel> GetAll(Guid environmentId);

        ReceivePaymentCulturalExchangeFileUploadViewModel GetById(Guid id);

        ReceivePaymentCulturalExchangeFileUploadViewModel Update(Guid environmentId, ReceivePaymentCulturalExchangeFileUploadViewModel paymentVM);

        void Delete(Guid id);
    }
}
