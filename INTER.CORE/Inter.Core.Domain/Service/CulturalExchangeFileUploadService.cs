﻿using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System;
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
            file.Id = Guid.NewGuid();
            file.UploadDate = DateTime.Now;

            return _culturalExchangeFileUploadRepository.Insert(file);
        }

        public void Delete(Guid id)
        {
            var entity = _culturalExchangeFileUploadRepository.GetById(id);

            _culturalExchangeFileUploadRepository.Delete(entity);
        }

        public List<CulturalExchangeFileUpload> GetAllByCulturalExchangeId(Guid culturalExchangeId)
        {
            return _culturalExchangeFileUploadRepository.FindByFilter(x => x.CulturalExchangeId == culturalExchangeId);
        }

        public CulturalExchangeFileUpload GetById(Guid id)
        {
            return _culturalExchangeFileUploadRepository.GetById(id);
        }

        public CulturalExchangeFileUpload Update(CulturalExchangeFileUpload file)
        {
            return _culturalExchangeFileUploadRepository.Update(file);
        }
    }
}
