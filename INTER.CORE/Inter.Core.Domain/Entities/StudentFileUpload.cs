using System;

namespace Inter.Core.Domain.Entities
{
    public class StudentFileUpload
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Type { get; set; }

        public DateTime UploadDate { get; set; }

        public string Note { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

    }
}
