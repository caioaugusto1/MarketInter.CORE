using DomainValidation.Interfaces.Specification;
using System;

namespace Inter.Core.Domain.Specification.Student
{
    public class StudentOver18YearsOld : ISpecification<Entities.Student>
    {
        public bool IsSatisfiedBy(Entities.Student entity)
        {
            if (DateTime.Now.AddYears(18) <= entity.DateOfBirthday)
                return false;

            return true;
        }
    }
}
