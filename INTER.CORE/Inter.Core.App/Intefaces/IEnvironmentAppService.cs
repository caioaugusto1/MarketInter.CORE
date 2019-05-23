using Inter.Core.App.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.App.Intefaces
{
    public interface IEnvironmentAppService
    {
        void Add(EnvironmentViewModel environmentVM);

        List<EnvironmentViewModel> GetAll();

        EnvironmentViewModel GetById(int id);

        EnvironmentViewModel GetByCode(string code);

        void Update(EnvironmentViewModel environment);
    }
}
