﻿using AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.App.Application
{
    public class CulturalExchangeFileUploadAppService : ICulturalExchangeFileUploadAppService
    {
        private readonly IMapper _mapper;
        private readonly ICulturalExchangeFileUploadService _culturalExchangeFileUploadService;

        public CulturalExchangeFileUploadAppService(IMapper mapper, ICulturalExchangeFileUploadService studentFileUploadService)
        {
            _mapper = mapper;
            _culturalExchangeFileUploadService = studentFileUploadService;
        }

        public CulturalExchangeFileUploadViewModel Add(CulturalExchangeFileUploadViewModel file)
        {
            var culturalExchangeFileUploadEntity = _mapper.Map<CulturalExchangeFileUpload>(file);

            return _mapper.Map<CulturalExchangeFileUploadViewModel>(_culturalExchangeFileUploadService.Add(culturalExchangeFileUploadEntity));
        }

        public void Delete(Guid id)
        {
            _culturalExchangeFileUploadService.Delete(id);
        }

        public List<CulturalExchangeFileUploadViewModel> GetAllByCulturalExchangeId(Guid studentId)
        {
            return _mapper.Map<List<CulturalExchangeFileUploadViewModel>>(_culturalExchangeFileUploadService.GetAllByCulturalExchangeId(studentId));
        }

        public CulturalExchangeFileUploadViewModel GetById(Guid id)
        {
            return _mapper.Map<CulturalExchangeFileUploadViewModel>(_culturalExchangeFileUploadService.GetById(id));
        }

        public CulturalExchangeFileUploadViewModel Update(CulturalExchangeFileUploadViewModel file)
        {
            var studentEntity = _mapper.Map<CulturalExchangeFileUpload>(file);

            return _mapper.Map<CulturalExchangeFileUploadViewModel>(_culturalExchangeFileUploadService.Update(studentEntity));
        }
    }
}
