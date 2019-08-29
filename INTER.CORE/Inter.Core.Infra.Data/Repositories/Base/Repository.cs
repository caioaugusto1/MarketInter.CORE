using Inter.Core.Domain.Interfaces.Repositories.Base;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inter.Core.Infra.Data.Repositories.Base
{
    public class Repository<TEntity> : IRepositoryGET<TEntity> where TEntity : class
    {
        private readonly string _connectionString;

        public Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySqlConnection");
        }

        public virtual async Task<List<TEntity>> GetAllByDapper(Guid idEnvironment)
        {
            var query = "SELECT * FROM intercore.CulturalExchange";

            //using (var connection = new MySqlConnection(_connectionString))
            //{
            //    await connection.
            //}

                throw new NotImplementedException();
        }
    }
}
