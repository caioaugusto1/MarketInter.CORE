using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly IEnvironmentRepository _environmentRepository;

        public EnvironmentService(IEnvironmentRepository environmentRepository)
        {
            _environmentRepository = environmentRepository;
        }

        public void Add(SystemEnvironment environment)
        {
            Random random = new Random(4);

            environment.CompanyCode = environment.CompanyCode + random;

            _environmentRepository.Insert(environment);
        }

        public List<SystemEnvironment> GetAll()
        {
            return _environmentRepository.GetAll();
        }

        public SystemEnvironment GetByCode(string code)
        {
            return _environmentRepository.GetByCode(code);
        }

        public SystemEnvironment GetById(int id)
        {
            return _environmentRepository.GetById(id);
        }

        public SystemEnvironment GetStudentsNotEnroled(int idEnvironment)
        {
            SystemEnvironment systemEnvironmentEntity = _environmentRepository.GetById(idEnvironment);

            var culturalExchangeEntity = systemEnvironmentEntity.CulturalExchange;

            return _environmentRepository.GetById(idEnvironment);
        }

        public void Update(SystemEnvironment environment)
        {
            _environmentRepository.Update(environment);
        }
    }
}
