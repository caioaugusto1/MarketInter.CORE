using DomainValidation.Interfaces.Specification;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.Domain.Specification.Student
{
    public class StudentOver18YearsOld : ISpecification<Entities.Student>
    {
        public bool IsSatisfiedBy(Entities.Student entity)
        {
            if (DateTime.Now.AddYears(18) <= entity.DateOfBirthday)
                entity.ValidationResult.Add(new ValidationResult("Student Under 18 years old"));

            return true;
        }
    }
}
