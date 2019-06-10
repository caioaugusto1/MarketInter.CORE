using System;

namespace Inter.Core.Domain.Entities
{
    public class CulturalExchangeFileUpload
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Type { get; set; }

        public DateTime UploadDate { get; set; }

        public string Note { get; set; }

        public int CulturalExchangeId { get; set; }

        public virtual CulturalExchange CulturalExchange { get; set; }

    }
}
