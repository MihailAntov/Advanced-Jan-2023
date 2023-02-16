using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            portfolio = new List<Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }  
        
        public IReadOnlyCollection<Stock> Portfolio { get { return portfolio; } }

        public int Count { get { return portfolio.Count; } }

        public void BuyStock(Stock stock)
        {
            if(stock.MarketCapitalization <= 10000 || MoneyToInvest <= stock.PricePerShare )
            {
                return;
            }

            portfolio.Add(stock);
            MoneyToInvest -= stock.PricePerShare;
        }

        public string SellStock (string companyName, decimal sellPrice)
        {
            Stock stockToSell = FindStock(companyName);
            if(stockToSell == null)
            {
                return $"{companyName} does not exist.";
            }

            if(sellPrice < stockToSell.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            portfolio.Remove(stockToSell);
            MoneyToInvest += sellPrice ;
            return $"{companyName} was sold.";
        }

        public Stock FindStock (string companyName)
        {
            return portfolio.SingleOrDefault(n=>n.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return portfolio.OrderByDescending(n => n.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach(Stock stock in portfolio)
            {
                str.AppendLine(stock.ToString());
            }
            return str.ToString().TrimEnd();
        }
    }
}
