namespace CryptoStats.Models.PersonalData
{
    public enum TypeExchange
    {
        WhiteBit = 0,
        GateIO = 1,
        Binance = 2
    }

    public class ExchangeDataItem
    {
        public long Id { get; set; }
        public TypeExchange Exchange { get; set; }
        public string APIKey { get; set; } = string.Empty;
        public string APISecret1 { get; set; } = string.Empty;
        public string APISecret2 { get; set; } = string.Empty;
        
    }
}
