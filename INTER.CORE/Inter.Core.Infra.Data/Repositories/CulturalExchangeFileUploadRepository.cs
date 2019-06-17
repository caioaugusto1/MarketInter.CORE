using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inter.Core.Infra.Data.Repositories
{
    public class CulturalExchangeFileUploadRepository : RepositoryBase<CulturalExchangeFileUpload>, ICulturalExchangeFileUploadRepository
    {
        private readonly DbContextOptions<MySQLContext> _OptionsBuilder;

        public CulturalExchangeFileUploadRepository()
        {
            _OptionsBuilder = new DbContextOptions<MySQLContext>();
        }

        public List<CulturalExchangeFileUpload> GetAllByCulturalExchangeId(Guid culturalExchangeId)
        {
            using (var db = new MySQLContext(_OptionsBuilder))
            {
                return db.CulturalExchangeFileUpload.Where(x => x.CulturalExchangeId == culturalExchangeId).ToList();
            }
        }
    }
}
