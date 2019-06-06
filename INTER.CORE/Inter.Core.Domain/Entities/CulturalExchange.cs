using System;

namespace Inter.Core.Domain.Entities
{
    public class CulturalExchange
    {
        public CulturalExchange()
        {
            Environment = new SystemEnvironment();
            Student = new Student();
            College = new College();
            Accomodation = new Accomodation();
        }

        public int Id { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int CollegeId { get; set; }

        public virtual College College { get; set; }

        public int AccomodationId { get; set; }

        public virtual Accomodation Accomodation { get; set; }

        public int DateOfAccomodation { get; set; }

        // After sprint, put class Insurance and crud create and edit insurance
        public bool INSUR { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime StartDate { get; set; }

        public string Company { get; set; }

        public string FlightNumber { get; set; }

        public bool CollegePayment { get; set; }

        public float TotalValue { get; set; }

        public int EnvironmentId { get; set; }

        public virtual SystemEnvironment Environment { get; set; }

        //public virtual List<CulturalExchangePayment> Payments { get; set; }

    }
}
