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

        public void Add(Entities.Environment environment)
        {
            _environmentRepository.Insert(environment);
        }

        public Task<List<Entities.Environment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Environment> GetByCode(string code)
        {
            return _environmentRepository.GetByCode(code);
        }

        public Entities.Environment GetById(int id)
        {
            return _environmentRepository.GetById(id);
        }

        public void Update(Entities.Environment environment)
        {
            throw new NotImplementedException();
        }
    }
}
