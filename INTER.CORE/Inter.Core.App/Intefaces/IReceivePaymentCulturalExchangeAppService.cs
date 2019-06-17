using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface IReceivePaymentCulturalExchangeAppService
    {
        ReceivePaymentCulturalExchangeViewModel Add(ReceivePaymentCulturalExchangeViewModel paymentVM);

        List<ReceivePaymentCulturalExchangeViewModel> GetAll(int environmentId);

        List<ReceivePaymentCulturalExchangeViewModel> GetAllIncludedDependency(int environmentId);

        ReceivePaymentCulturalExchangeViewModel GetById(Guid id);

        ReceivePaymentCulturalExchangeViewModel Update(int environmentId, ReceivePaymentCulturalExchangeViewModel paymentVM);

        void Delete(Guid id);
    }
}
