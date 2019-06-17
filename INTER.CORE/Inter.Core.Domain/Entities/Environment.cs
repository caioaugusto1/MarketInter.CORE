using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inter.Core.Domain.Entities
{
    [Table("Environment")]
    public class SystemEnvironment
    {
        public SystemEnvironment()
        {
            Users = new List<ApplicationUser>();
            Students = new List<Student>();
            Accomodations = new List<Accomodation>();
        }

        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyCode { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public bool Available { get; set; }

        public virtual List<ApplicationUser> Users { get; set; }

        public virtual List<Student> Students { get; set; }

        public virtual List<Accomodation> Accomodations { get; set; }

        //public virtual List<Advisor> Advisors { get; set; }

        public virtual List<College> Colleges { get; set; }

        public virtual List<CulturalExchange> CulturalExchange { get; set; }

        public virtual List<ReceivePaymentCulturalExchange> ReceivePaymentsCulturalExchanges { get; set; }
    }
}
