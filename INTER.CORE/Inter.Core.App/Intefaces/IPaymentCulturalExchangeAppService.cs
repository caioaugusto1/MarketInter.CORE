using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface IPaymentCulturalExchangeAppService
    {
        PaymentCulturalExchangeViewModel Add(PaymentCulturalExchangeViewModel paymentVM);

        List<PaymentCulturalExchangeViewModel> GetAll(Guid idEnvironment);

        PaymentCulturalExchangeViewModel GetById(Guid id);

        PaymentCulturalExchangeViewModel Update(Guid idEnvironment, PaymentCulturalExchangeViewModel paymentVM);
    }
}
