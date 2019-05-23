using System;

namespace Inter.Core.Domain.Entities
{
    public class CulturalExchange
    {
        public int Id { get; set; }
        
        public virtual Student Student { get; set; }
        
        public virtual College College { get; set; }
        
        // After sprint, put class Insurance and crud create and edit insurance
        public bool INSUR { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime StartDate { get; set; }

        public string Company { get; set; }

        public string FlightNumber { get; set; }

        public bool CollegePayment { get; set; }

        public float TotalValue { get; set; }
        
        public virtual Environment Environment { get; set; }

    }
}
