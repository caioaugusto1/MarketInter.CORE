using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Inter.Core.App.JsonModels
{
    public class HomeDashoboardInfoJson
    {
        public HomeDashoboardInfoJson()
        {
            TotalThisMonth = new CulturalExchangeThisMonth();
            TotalPerMonth = new List<CulturalExchangePerMonthToShowGraphics>();
        }

        public CulturalExchangeThisMonth TotalThisMonth { get; set; }

        public List<CulturalExchangePerMonthToShowGraphics> TotalPerMonth { get; set; }

        public class CulturalExchangeThisMonth
        {
            [JsonProperty(PropertyName = "total")]
            public int Total { get; set; }
        }

        public class CulturalExchangePerMonthToShowGraphics
        {
            [JsonProperty(PropertyName = "month")]
            public string Month { get; set; }

            [JsonProperty(PropertyName = "monthName")]
            public string MonthName { get; set; }

            public string Year { get; set; }

            [JsonProperty(PropertyName = "culturalExchangeTotal")]
            public int CulturalExchangeTotal { get; set; }
        }
    }
}
