using Inter.Core.App.ViewModel;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface IAccomodationAppService
    {
        AccomodationViewModel Add(AccomodationViewModel accomodationViewModel);

        List<AccomodationViewModel> GetAll();

        AccomodationViewModel GetById(int id);

        AccomodationViewModel Update(AccomodationViewModel accomodationViewModel);
    }
}
