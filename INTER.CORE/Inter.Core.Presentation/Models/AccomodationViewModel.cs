using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inter.Core.Presentation.Models
{
    public class AccomodationViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Identifier { get; set; }

        public string Address { get; set; }

        public string ContactName { get; set; }

        public string ContactNumber { get; set; }

        public string NumberOfPlaces { get; set; }

        public bool Available { get; set; }
        
        public int EnviromentId { get; set; }

        public virtual EnvironmentViewModel EnvironmentViewModel { get; set; }
    }
}
