using System.ComponentModel.DataAnnotations;

namespace Inter.Core.Presentation.Models
{
    public class AdvisorViewModel
    {
        [Key]
        public string AdvisorId { get; set; }

        public string Name { get; set; }

        public string EnviromentId { get; set; }

        public virtual EnvironmentViewModel EnvironmentViewModel { get; set; }
    }
}
