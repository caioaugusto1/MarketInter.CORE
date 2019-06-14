using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
{
    public class ReceivePaymentCulturalExchangeViewModel/* : BaseViewModel*/
    {
        public string Id { get; set; }

        public int EnviromentId { get; set; }

        public virtual EnvironmentViewModel EnvironmentViewModel { get; set; }

        //public virtual List<CulturalExchangeFileUploadViewModel> Files { get; set; }

        [ScaffoldColumn(false)]
        public List<ValidationResult> ValidationResult { get; set; }

        public float Value { get; set; }

        [Display(Name = "Finish Accomodation")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.DateTime, ErrorMessage = "Incorrect Format")]
        public DateTime DateOfPayment { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public virtual ReceivePaymentCulturalExchangeFileUploadViewModel ReceivePaymentCulturalExchangeFileUploadViewModel { get; set; }

        public int CulturalExchangeId { get; set; }

        public virtual CulturalExchangeViewModel CulturalExchange { get; set; }
    }
}
