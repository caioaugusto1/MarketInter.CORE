using System.Data;

namespace Inter.Core.Infra.Data.Repositories.Interface
{
    public interface IConnectationFactory
    {
        IDbConnection Connection(string connectionString);
    }
}
