using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Service
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly IEnvironmentRepository _environmentRepository;

        public EnvironmentService(IEnvironmentRepository environmentRepository)
        {
            _environmentRepository = environmentRepository;
        }

        public void Add(Entities.SystemEnvironment environment)
        {
            Random random = new Random(4);

            environment.CustomerCode = environment.CustomerCode + random;
            
            _environmentRepository.Insert(environment);
        }

        public Task<List<Entities.SystemEnvironment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.SystemEnvironment> GetByCode(string code)
        {
            return _environmentRepository.GetByCode(code);
        }

        public Entities.SystemEnvironment GetById(int id)
        {
            return _environmentRepository.GetById(id);
        }

        public void Update(Entities.SystemEnvironment environment)
        {
            throw new NotImplementedException();
        }
    }
}
