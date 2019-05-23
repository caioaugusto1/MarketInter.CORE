using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.ViewModel
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
