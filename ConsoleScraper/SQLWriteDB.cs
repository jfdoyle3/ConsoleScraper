﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ConsoleScraper
{
    public class SQLWriteDB
    {
        public static void HAPDBStocks(List<List<string>> stockData)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Connecting to DB: ");
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HapDB;Integrated Security=True";

            string type = "HAP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Successful\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Writing to HapDB: ");
                for (int i = 0; i < stockData.Count; i++)
                 {
                    connection.Open();

                    SqlCommand insertStatement = new SqlCommand("INSERT into [HapStocks] (DateStamp, Symbol, LastPrice, Change, ChgPc, MarketTime, Volume, AvgVol3m, MarketCap,Method) VALUES (@DateStamp, @Symbol, @LastPrice, @Change, @ChgPc, @MarketTime, @Volume, @AvgVol3m, @MarketCap, @Method)", connection);
                    insertStatement.Parameters.AddWithValue("@DateStamp", DateTime.Now.ToString());
                    insertStatement.Parameters.AddWithValue("@Symbol", stockData[i][0].ToString());
                    insertStatement.Parameters.AddWithValue("@LastPrice", stockData[i][1].ToString());
                    insertStatement.Parameters.AddWithValue("@Change", stockData[i][2].ToString());
                    insertStatement.Parameters.AddWithValue("@ChgPc", stockData[i][3].ToString());
                    insertStatement.Parameters.AddWithValue("@MarketTime", stockData[i][5].ToString());
                    insertStatement.Parameters.AddWithValue("@Volume", stockData[i][6].ToString());
                    insertStatement.Parameters.AddWithValue("@AvgVol3m", stockData[i][8].ToString());
                    insertStatement.Parameters.AddWithValue("@MarketCap", stockData[i][12].ToString());
                    insertStatement.Parameters.AddWithValue("@Method", type);

                    
                    insertStatement.ExecuteNonQuery();
                    connection.Close();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Successful");
            }
        }
    }
}