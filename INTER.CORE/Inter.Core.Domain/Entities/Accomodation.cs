using Inter.Core.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Inter.Core.Domain.Entities
{
    public class Accomodation : EntityBase
    {
        public string Identifier { get; set; }

        public string Address { get; set; }

        public string ContactName { get; set; }

        public string ContactNumber { get; set; }

        public int NumberOfPlaces { get; set; }

        public bool Available { get; set; }

        public virtual List<CulturalExchange> CulturalExchanges { get; set; }

        public Guid DestinationId { get; set; }

        public Destination Destination { get; set; }

    }
}
