using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface IReceivePaymentCulturalExchangeAppService
    {
        ReceivePaymentCulturalExchangeViewModel Add(ReceivePaymentCulturalExchangeViewModel paymentVM);

        List<ReceivePaymentCulturalExchangeViewModel> GetAll(Guid environmentId);

        List<ReceivePaymentCulturalExchangeViewModel> GetAllIncludedDependency(Guid environmentId);

        ReceivePaymentCulturalExchangeViewModel GetById(Guid id);

        ReceivePaymentCulturalExchangeViewModel Update(Guid environmentId, ReceivePaymentCulturalExchangeViewModel paymentVM);

        void Delete(Guid id);
    }
}
