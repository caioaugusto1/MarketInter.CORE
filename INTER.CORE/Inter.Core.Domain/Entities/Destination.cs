using Inter.Core.Domain.Entities.Base;

namespace Inter.Core.Domain.Entities
{
    public class Destination : EntityBase
    {
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
