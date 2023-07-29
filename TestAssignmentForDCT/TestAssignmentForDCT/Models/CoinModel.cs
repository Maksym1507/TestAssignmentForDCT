namespace TestAssignmentForDCT.Models
{
    public class CoinModel
    {
        public string Id { get; set; }

        public int Rank { get; set; }

        public string Name { get; set; }

        public string VolumeUsd24Hr { get; set; }

        public string PriceUsd { get; set; }

        public string ChangePercent24Hr { get; set; }

        public string Vwap24Hr { get; set; }
    }
}
