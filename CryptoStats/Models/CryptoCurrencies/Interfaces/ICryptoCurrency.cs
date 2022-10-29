namespace CryptoStats.Models.CryptoCurrencies.Interfaces
{
    public interface ICryptoCurrency
    {
        string Name { get; }
        string Code { get; }
        bool CanWithdraw { get; }
        bool CanDeposit { get; }
        bool IsMemo { get; }
        int CurrencyPrecision { get; }
        IEnumerable<ICryptoChain> DepositChains { get; }
        IEnumerable<ICryptoChain> WithdrawChains { get; }
    }
}
