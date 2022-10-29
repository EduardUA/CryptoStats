using CryptoStats.Models.CryptoCurrencies.Interfaces;

namespace CryptoStats.Models.CryptoCurrencies.Implementations
{
    public class CryptoChain : ICryptoChain
    {
        public string Name { get; private set; } = String.Empty;

        public decimal Min { get; private set; }

        public decimal Max { get; private set; }

        public decimal FeePrc { get; private set; }

        public decimal Fee { get; private set; }
    }
}
