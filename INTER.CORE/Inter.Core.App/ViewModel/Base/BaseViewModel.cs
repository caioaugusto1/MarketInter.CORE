using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel.Base
{
    public class BaseViewModel
    {
        [Key]
        public int Id { get; set; }

        public int EnviromentId { get; set; }

        public virtual EnvironmentViewModel EnvironmentViewModel { get; set; }

        //public virtual List<CulturalExchangeFileUploadViewModel> Files { get; set; }

        [ScaffoldColumn(false)]
        public List<ValidationResult> ValidationResult { get; set; }
    }
}
