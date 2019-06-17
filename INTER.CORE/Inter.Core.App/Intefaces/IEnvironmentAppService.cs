using Inter.Core.App.ViewModel;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Intefaces
{
    public interface IEnvironmentAppService
    {
        void Add(EnvironmentViewModel environmentVM);

        List<EnvironmentViewModel> GetAll();

        EnvironmentViewModel GetById(Guid id);

        EnvironmentViewModel GetByCode(string code);

        void Update(EnvironmentViewModel environment);
    }
}
