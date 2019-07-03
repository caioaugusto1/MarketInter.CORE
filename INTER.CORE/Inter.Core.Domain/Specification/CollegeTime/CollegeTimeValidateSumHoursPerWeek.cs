using DomainValidation.Interfaces.Specification;
using System;

namespace Inter.Core.Domain.Specification.CollegeTime
{
    public class CollegeTimeValidateSumHoursPerWeek : ISpecification<Entities.CollegeTime>
    {
        public bool IsSatisfiedBy(Entities.CollegeTime entity)
        {
            TimeSpan time = entity.FinishTime - entity.StartTime;

            entity.TimeForWeek = Convert.ToInt32(time.Hours * entity.DaysOfWeek);

            return true;
        }
    }
}
