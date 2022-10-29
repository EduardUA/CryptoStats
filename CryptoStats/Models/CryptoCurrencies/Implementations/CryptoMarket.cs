using CryptoStats.Models.CryptoCurrencies.Interfaces;

namespace CryptoStats.Models.CryptoCurrencies.Implementations
{
    public class CryptoMarket : ICryptoMarket
    {        
        public string Name { get; private set; } = String.Empty;

        public string Stock { get; private set; } = String.Empty;

        public string Money { get; private set; } = String.Empty;

        public int StockPrec { get; private set; }

        public int MoneyPrec { get; private set; }

        public int FeePrec { get; private set; }

        public decimal MakerFee { get; private set; }

        public decimal TakerFee { get; private set; }

        public decimal MinStock { get; private set; }

        public decimal MinMoney { get; private set; }

        public bool TradesEnable { get; private set; } = false;
    }
}
