using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.Domain.Entities
{
    public class CollegeTime
    {
        public Guid Id { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan FinishTime { get; set; }

        public int DaysOfWeek { get; set; }

        public int TimeForWeek { get; set; }

        public string Period { get; set; }

        public decimal Price { get; set; }

        public decimal BookPrice { get; set; }

        public decimal ExamPrice { get; set; }

        public decimal InsurancePrice { get; set; }

        public decimal AccomodationPrice { get; set; }

        public decimal NetPrice { get; set; }

        public decimal GrossPrice { get; set; }

        public decimal RenewPrice { get; set; }

        public int PercentagePrice { get; set; }

        public Guid CollegeId { get; set; }

        public virtual College College { get; set; }

        public string Note { get; set; }

        //public List<ValidationResult> ValidationResults { get; set; }
    }
}
