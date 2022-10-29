namespace CryptoStats.Models.CryptoCurrencies.Interfaces
{
    public interface ICryptoChain
    {
        string Name { get; }
        decimal Min { get; }
        decimal Max { get; }
        public decimal FeePrc { get; }
        public decimal Fee { get; }
    }
}
