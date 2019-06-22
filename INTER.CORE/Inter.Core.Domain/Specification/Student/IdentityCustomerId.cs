using DomainValidation.Interfaces.Specification;
using Inter.Core.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.Domain.Specification.Student
{
    public class IdentityCustomerId : ISpecification<Entities.Student>
    {
        private readonly IStudentRepository _studentRepository;

        public IdentityCustomerId(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public bool IsSatisfiedBy(Entities.Student entity)
        {
            bool validationCustomerId = _studentRepository.ValidationCustomerId(entity.CustomerId);

            if (validationCustomerId)
                entity.ValidationResult.Add(new ValidationResult("Customer Id Incorrect"));
                
            return true;
        }
    }
}
