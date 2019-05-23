using System;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.Presentation.Models
{
    public class CulturalExchangeViewModel
    {
        [Key]
        public int Id { get; set; }

        public string IdStudent { get; set; }

        public virtual StudentViewModel StudentViewModel { get; set; }

        public string CollegeId { get; set; }

        public virtual CollegeViewModel CollegeViewModel { get; set; }

        // After sprint, put class Insurance and crud create and edit insurance
        public bool INSUR { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime StartDate { get; set; }

        public string Company { get; set; }

        public string FlightNumber { get; set; }

        public bool CollegePayment { get; set; }

        public string TotalValue { get; set; }

        public int EnviromentId { get; set; }

        public virtual EnvironmentViewModel EnvironmentViewModel { get; set; }
    }
}
