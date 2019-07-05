using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Inter.Core.App.JsonModels
{
    public class CulturalExchangeLast12MonthToShowGraphics
    {
        [JsonProperty(PropertyName = "month")]
        public int Month { get; set; }

        [JsonProperty(PropertyName = "culturalExchangeTotal")]
        public int CulturalExchangeTotal { get; set; }
    }
}
