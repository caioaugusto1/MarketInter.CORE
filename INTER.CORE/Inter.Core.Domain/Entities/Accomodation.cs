namespace Inter.Core.Domain.Entities
{
    public class Accomodation
    {
        public int Id { get; set; }

        public string Identifier { get; set; }

        public string Address { get; set; }

        public string ContactName { get; set; }

        public string ContactNumber { get; set; }
        
        public int NumberOfPlaces { get; set; }

        public bool Available { get; set; }
        
    }
}
