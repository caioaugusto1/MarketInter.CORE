using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            CulturalExchangeFileUpload = new List<CulturalExchangeFileUpload>();
        }

        public int Id { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int CollegeId { get; set; }

        public virtual College College { get; set; }

        public int CollegeTimeId { get; set; }

        public virtual CollegeTime CollegeTime { get; set; }

        public int AccomodationId { get; set; }

        public virtual Accomodation Accomodation { get; set; }

        public int DateOfAccomodation { get; set; }

        public DateTime StartAccomodation { get; set; }

        public DateTime FinishAccomodation { get; set; }

        // After sprint, put class Insurance and crud create and edit insurance
        public bool INSUR { get; set; }

        public bool Transfer { get; set; }

        public bool Support { get; set; }

        public bool Kit { get; set; }

        public bool SimCard { get; set; }

        public bool IncludeAccomodation { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime StartDate { get; set; }

        public string Company { get; set; }

        public string FlightNumber { get; set; }

        public bool CollegePayment { get; set; }

        public float TotalValue { get; set; }

        public string SalesMen { get; set; }

        public int EnvironmentId { get; set; }

        public virtual SystemEnvironment Environment { get; set; }

        public virtual List<CulturalExchangeFileUpload> CulturalExchangeFileUpload { get; set; }

        public virtual List<ReceivePaymentCulturalExchange> ReceivePaymentCulturalExchanges { get; set; }

        [NotMapped]
        public List<ValidationResult> ValidationResult { get; set; }

        //public virtual List<CulturalExchangePayment> Payments { get; set; }

    }
}
