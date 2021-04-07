using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    class MonthlyData
    {
        public MonthlyData(Dictionary<DateTime, decimal> data)
        {
            weekly = new List<WeeklyData>();

            //Find first Monday of month
            DateTime startDate = data.Last().Key;
            int month = startDate.Month;
            var dayToMonday = Math.Abs(DayOfWeek.Monday - startDate.DayOfWeek);
            startDate = startDate.AddDays(dayToMonday - 1);

            //Separate data to weekly
            while (startDate.AddDays(5).Month == month)
            {
                var weekDays = data.Where(x => x.Key >= startDate && x.Key < startDate.AddDays(5)).ToDictionary(p => p.Key, p => p.Value);
                weekly.Add(new WeeklyData(weekDays));
                startDate = startDate.AddDays(7);
            }
        }

        public void GetWeeklyMaxProfit()
        {
            foreach (WeeklyData wd in weekly)
            {
                var result = wd.getMaxProfit(wd.getDataCount() - 1, 1);
                System.Console.Write("Maximum profit week {0} to {1} is {2},", wd.startDate.ToString("MM/dd/yyyy"), wd.startDate.AddDays(5).ToString("MM/dd/yyyy"), result.maximum);
                result.logAllTransactions();
            }
        }
        private List<WeeklyData> weekly;
    }
}
