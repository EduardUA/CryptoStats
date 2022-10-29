using CryptoStats.Models.CryptoCurrencies.Interfaces;

namespace CryptoStats.Models.CryptoCurrencies.Implementations
{
    public class CryptoCurrency : ICryptoCurrency
    {
        public string Name { get; private set; } = String.Empty;

        public string Code { get; private set; } = String.Empty;

        public bool CanWithdraw { get; private set; }

        public bool CanDeposit { get; private set; }

        public bool IsMemo { get; private set; }

        public int CurrencyPrecision { get; private set; }

        public IEnumerable<ICryptoChain> DepositChains { get; private set; } = Enumerable.Empty<ICryptoChain>();

        public IEnumerable<ICryptoChain> WithdrawChains { get; private set; } = Enumerable.Empty<ICryptoChain>();
    }
}
