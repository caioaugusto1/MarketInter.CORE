using Inter.Core.Domain.Entities.Base;
using System;

namespace Inter.Core.Domain.Entities
{
    public class Student : EntityBase
    {
        public string CustomerId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public DateTime DateOfBirthday { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Nationality { get; set; }

        public string PassaportNumber { get; set; }

        public DateTime PassaportDateOfIssue { get; set; }

        public DateTime PassaportDateOfExpiry { get; set; }
    }
}
