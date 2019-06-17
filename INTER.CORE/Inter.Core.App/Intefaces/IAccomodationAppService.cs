﻿using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface IAccomodationAppService
    {
        AccomodationViewModel Add(Guid environmentId, AccomodationViewModel accomodationViewModel);

        List<AccomodationViewModel> GetAll(Guid idEnvironment);

        AccomodationViewModel GetById(Guid id);

        AccomodationViewModel Update(AccomodationViewModel accomodationViewModel);
    }
}
