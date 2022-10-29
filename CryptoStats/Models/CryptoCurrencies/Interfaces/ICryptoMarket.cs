namespace CryptoStats.Models.CryptoCurrencies.Interfaces
{
    public interface ICryptoMarket
    {
        string Name { get; }        // Market pair name
        string Stock { get; }       // Ticker of stock currency
        string Money { get; }       // Ticker of money currency
        int StockPrec { get; }      // Stock currency precision
        int MoneyPrec { get; }      // Precision of money currency
        int FeePrec { get; }        // Fee precision
        decimal MakerFee { get; }   // Default maker fee ratio
        decimal TakerFee { get; }   // Default taker fee ratio
        decimal MinStock { get; }   // Minimal amount of stock to trade
        decimal MinMoney { get; }   // Minimal amount of money to trade
        bool TradesEnable { get; }  // Is trading enabled
    }
    //"name": "SON_USD",         // Market pair name
    //"stock": "SON",            // Ticker of stock currency
    //"money": "USD",            // Ticker of money currency
    //"stockPrec": "3",          // Stock currency precision
    //"moneyPrec": "2",          // Precision of money currency
    //"feePrec": "4",            // Fee precision
    //"makerFee": "0.001",       // Default maker fee ratio
    //"takerFee": "0.001",       // Default taker fee ratio
    //"minAmount": "0.001",      // Minimal amount of stock to trade
    //"minTotal": "0.001",       // Minimal amount of money to trade
    //"tradesEnabled": true      // Is trading enabled
}
