using Newtonsoft.Json;

namespace TestAssignmentForDCT.Models
{
    public class CoinModel
    {
        public string Id { get; set; }

        public int Rank { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public double? Supply { get; set; }

        public double? MaxSupply { get; set; }

        public double? MarketCapUsd { get; set; }

        [JsonProperty("volumeUsd24Hr")]
        public double? Volume { get; set; }

        [JsonProperty("priceUsd")]
        public double? Price { get; set; }

        [JsonProperty("changePercent24Hr")]
        public double? Change { get; set; }

        [JsonProperty("vwap24Hr")]
        public double? Vwap { get; set; }
    }
}
