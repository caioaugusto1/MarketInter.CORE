using Inter.Core.App.Enumerables;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class CulturalExchangeFileUploadViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public IFormFile File { get; set; }

        [Required]
        public CulturalExchangeTypeFileUpload Type { get; set; }

        public string FileName { get; set; }

        public DateTime UploadDate { get; set; }

        [MaxLength(30, ErrorMessage = "Max {0} caracteres")]
        [MinLength(2, ErrorMessage = "Min {0} caracteres")]
        [DisplayName("Note")]
        public string Note { get; set; }

        public Guid CulturalExchangeId { get; set; }

        public virtual CulturalExchangeViewModel CulturalExchangeViewModel { get; set; }
    }
}
