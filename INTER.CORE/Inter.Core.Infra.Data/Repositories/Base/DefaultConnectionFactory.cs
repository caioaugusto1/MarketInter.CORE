using Inter.Core.Infra.Data.Repositories.Interface;
using System.Data;
using System.Data.SqlClient;

namespace Inter.Core.Infra.Data.Repositories.Base
{
    public class DefaultConnectionFactory : IConnectationFactory
    {
        public IDbConnection Connection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
