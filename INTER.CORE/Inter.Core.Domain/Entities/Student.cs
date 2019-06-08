﻿using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Entities
{
    public class Student
    {
        public Student()
        {
            Files = new List<StudentFileUpload>();
        }

        public int Id { get; set; }

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

        public int EnvironmentId { get; set; }

        public virtual SystemEnvironment Environment { get; set; }

        public virtual List<StudentFileUpload> Files { get; set; }
    }
}
