using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Service
{
    public class AccomodationService : IAccomodationService
    {
        private readonly IAccomodationRepository _accomodationRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICollegeRepository _collegeRepository;
        private readonly ICollegeTimeRepository _collegeTimeRepository;


        public AccomodationService(IAccomodationRepository accomodationRepository, IStudentRepository studentRepository,
            ICollegeRepository collegeRepository, ICollegeTimeRepository collegeTimeRepository)
        {
            _accomodationRepository = accomodationRepository;
            _studentRepository = studentRepository;
            _collegeRepository = collegeRepository;
            _collegeTimeRepository = collegeTimeRepository;
        }

        public Accomodation Add(Accomodation accomodation)
        {
            accomodation.Id = Guid.NewGuid();

            return _accomodationRepository.Insert(accomodation);
        }

        public Accomodation GetAccomodationAndCulturalExchangeList(Guid id)
        {
            var accomodation = _accomodationRepository.GetAccomodationAndCulturalExchangeList(id);

            accomodation.CulturalExchanges.ForEach(ce =>
            {
                ce.Student = _studentRepository.GetById(ce.StudentId);
                ce.CollegeTime = _collegeTimeRepository.GetById(ce.CollegeTimeId);
                ce.College = _collegeRepository.GetById(ce.CollegeId);
            });

            return accomodation;
        }

        public List<Accomodation> GetAll(Guid idEnvironment)
        {
            return _accomodationRepository.FindByFilter(x => x.EnvironmentId == idEnvironment);
        }

        public List<Accomodation> GetAllAvaliable(Guid idEnvironment)
        {
            return _accomodationRepository.FindByFilter(x => x.EnvironmentId == idEnvironment && x.Available);
        }

        public Accomodation GetById(Guid id)
        {
            return _accomodationRepository.GetById(id);
        }

        public Accomodation Update(Accomodation accomodation)
        {
            return _accomodationRepository.Update(accomodation);
        }
    }
}
