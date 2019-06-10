using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inter.Core.Domain.Entities.Base
{
    public class EntityBase
    {
        public int Id { get; set; }

        public int EnvironmentId { get; set; }

        public virtual SystemEnvironment Environment { get; set; }

        [NotMapped]
        public List<ValidationResult> ValidationResult { get; set; }
    }
}
