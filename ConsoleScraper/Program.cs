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

            for (var i = 0; i < stockTable.Count; i++)
            {
                for (int j = 0; j < stockTable[0].Count; j++)
                {
                    Console.WriteLine(stockTable[i][j].ToString());
                }
            }
            //
            FinanceTable.ScrapeToDatabase(stockTable);
        }
    }
}
