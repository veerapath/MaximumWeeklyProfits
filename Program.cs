using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<DateTime, decimal> goldSpot = new Dictionary<DateTime, decimal>();

            //Load data from csv file
            using (var reader = new StreamReader(@"../../gold.csv"))
            {
                //Skip header
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    DateTime oDate = DateTime.Parse(values[0]);
                    decimal value = decimal.Parse(values[1]);
                    goldSpot.Add(oDate, value);
                }
            }

            //Set month
            int [] targetMonths = new int[] { 3, 6, 9, 12 };

            foreach (int month in targetMonths)
            {
                //Query for specific months
                var monthly = goldSpot.Where(x => x.Key.Month == month).ToDictionary(p => p.Key, p => p.Value);
                MonthlyData monthlyData = new MonthlyData(monthly);
                monthlyData.GetWeeklyMaxProfit();
            }
        }
    }
}
