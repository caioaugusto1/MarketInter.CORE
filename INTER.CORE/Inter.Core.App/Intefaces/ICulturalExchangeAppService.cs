using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface ICulturalExchangeAppService
    {
        CulturalExchangeViewModel Add(int idEnvironment, CulturalExchangeViewModel culturalExchangeViewModel);

        List<CulturalExchangeViewModel> GetAll(int idEnvironment);

        CulturalExchangeViewModel GetById(int id);

        CulturalExchangeViewModel Update(CulturalExchangeViewModel culturalExchangeViewModel);
    }
}
