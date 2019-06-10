using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class CulturalExchangeFileUploadService : ICulturalExchangeFileUploadService
    {
        private readonly ICulturalExchangeFileUploadRepository _culturalExchangeFileUploadRepository;

        public CulturalExchangeFileUploadService(ICulturalExchangeFileUploadRepository culturalExchangeFileUploadRepository)
        {
            _culturalExchangeFileUploadRepository = culturalExchangeFileUploadRepository;
        }

        public CulturalExchangeFileUpload Add(CulturalExchangeFileUpload file)
        {
            return _culturalExchangeFileUploadRepository.Insert(file);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<CulturalExchangeFileUpload> GetAllByCulturalExchangeId(int culturalExchangeId)
        {
            return _culturalExchangeFileUploadRepository.FindByFilter(x => x.CulturalExchangeId == culturalExchangeId);
        }

        public CulturalExchangeFileUpload GetById(int id)
        {
            return _culturalExchangeFileUploadRepository.GetById(id);
        }

        public CulturalExchangeFileUpload Update(CulturalExchangeFileUpload file)
        {
            return _culturalExchangeFileUploadRepository.Update(file);
        }
    }
}
