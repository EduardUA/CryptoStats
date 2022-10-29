using CryptoStats.Models.CryptoCurrencies.Interfaces;

namespace CryptoStats.Models.CryptoExchange.Interfaces
{
    public interface ICryptoExchange
    {
        string Name { get; }
        Task<IEnumerable<ICryptoMarket>> GetMarkets();
        Task<IEnumerable<ICryptoCurrency>> GetCurrencies();
        Task<IEnumerable<ICryptoCurrency>> GetBalances();
    }
}
