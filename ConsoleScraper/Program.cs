using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            //FromFile scrape = new FromFile();
            // List<List<string>> stockTable = scrape.ReadFile();

            YahooFinance scrape = new YahooFinance();
            List<List<string>> stockTable = scrape.Login();

            FinanceTable.ScrapeToDatabase(stockTable);
        }
    }
}
