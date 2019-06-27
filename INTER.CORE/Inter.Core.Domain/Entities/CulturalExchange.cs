using Inter.Core.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Entities
{
    public class CulturalExchange : EntityBase
    {
        public CulturalExchange()
        {
            Environment = new SystemEnvironment();
            Student = new Student();
            College = new College();
            Accomodation = new Accomodation();
            CulturalExchangeFileUpload = new List<CulturalExchangeFileUpload>();
        }

        public Guid StudentId { get; set; }

        public virtual Student Student { get; set; }

        public Guid CollegeId { get; set; }

        public virtual College College { get; set; }

        public Guid CollegeTimeId { get; set; }

        public virtual CollegeTime CollegeTime { get; set; }

        public Guid AccomodationId { get; set; }

        public virtual Accomodation Accomodation { get; set; }

        public int WeekNumber { get; set; }

        public int DaysOfAccomodation { get; set; }

        public DateTime StartAccomodation { get; set; }

        public DateTime FinishAccomodation { get; set; }

        // After sprint, put class Insurance and crud create and edit insurance
        public bool INSUR { get; set; }

        public bool Transfer { get; set; }

        public bool Support { get; set; }

        public bool Kit { get; set; }

        public bool SimCard { get; set; }

        public bool OurAccomodation { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime StartDate { get; set; }

        public string Company { get; set; }

        public string FlightNumber { get; set; }

        public bool CollegePayment { get; set; }

        public float TotalValue { get; set; }

        public string SalesMen { get; set; }

        public bool Available { get; set; } 

        public virtual List<CulturalExchangeFileUpload> CulturalExchangeFileUpload { get; set; }

        public virtual List<ReceivePaymentCulturalExchange> ReceivePaymentCulturalExchanges { get; set; }

        //public virtual List<CulturalExchangePayment> Payments { get; set; }

    }
}
