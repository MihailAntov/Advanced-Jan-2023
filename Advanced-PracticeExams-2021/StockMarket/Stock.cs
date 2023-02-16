using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
        }

        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get { return TotalNumberOfShares * PricePerShare; } }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Company: {CompanyName}");
            str.AppendLine($"Director: {Director}");
            str.AppendLine($"Price per share: ${PricePerShare}");
            str.AppendLine($"Market capitalization: ${MarketCapitalization}");

            return str.ToString().TrimEnd();
        }
    }
}
