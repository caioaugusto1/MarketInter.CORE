using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Entities
{
    public class Environment
    {
        public int Id { get; set; }

        public string Company { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public virtual List<IdentityUser> Users { get; set; }

        public virtual List<Student> Students { get; set; }

        public virtual List<Accomodation> Accomodations { get; set; }

        public virtual List<Advisor> Advisors { get; set; }

        public virtual List<College> Colleges { get; set; }

        public int CulturalExchangeId { get; set; }

        public virtual CulturalExchange CulturalExchange { get; set; }
    }
}
