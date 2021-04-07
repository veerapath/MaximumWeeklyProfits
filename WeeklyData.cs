using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication
{
    class WeeklyData
    {
        public DateTime startDate { get; set; }
        public int getDataCount() { return size; }
        public WeeklyData(Dictionary<DateTime, decimal> Wdata)
        {
            startDate = Wdata.Last().Key;
            data = Wdata;
            size = data.Count;
        }

        public TransactionRecord getMaxProfit(int index, int maxTransactionCount)
        {
            decimal maxLocal = 0;
            TransactionRecord record = new TransactionRecord();

            //Attempt to try eveery possible transaction
            for (int k = 0; k < maxTransactionCount; k++)
            {
                for (int i = index; i >= 0; i--)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        // Max of sub transaction's profit
                         TransactionRecord subTransaction = getMaxProfit(j - 1, maxTransactionCount - 1);
                        
                        //Sum of current profit = current transaction's profit + max of sub transaction's profit
                        decimal tmpProfit = (data.ElementAt(j).Value - data.ElementAt(i).Value) + subTransaction.maximum;

                        //Store information when curent transaction gain temporary maximum profit
                        if (tmpProfit >= maxLocal)
                        {
                            maxLocal = tmpProfit;

                            record = subTransaction;
                            record.addNewTransaction(new TransactionInfo(data.ElementAt(i).Key, data.ElementAt(i).Value, data.ElementAt(j).Key, data.ElementAt(j).Value));
                            record.maximum = maxLocal;
                        }
                    }
                }
            }

            return record;
        }

        private Dictionary<DateTime, decimal> data;
        private int size;
    }
   
}
