using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public struct TransactionInfo
    {
        public TransactionInfo(DateTime buyDate, Decimal buyAt,  DateTime saleDate, Decimal saleAt)
        {
            BuyDate = buyDate;
            BuyAt = buyAt;
            SaleDate = saleDate;
            SaleAt = saleAt;
        }

        public DateTime BuyDate { get; }
        public DateTime SaleDate { get; }
        public Decimal BuyAt { get; }
        public Decimal SaleAt { get; }
        public override string ToString() => $"buy at {BuyAt} on {BuyDate}, sale at {SaleAt}, {SaleDate}";
    }

    class TransactionRecord
    {
        public TransactionRecord()
        {
            maximum = 0;
            transactionList = new List<TransactionInfo>();
        }

        public void addNewTransaction(TransactionInfo transaction)
        {
            transactionList.Insert(0, transaction);
        }

        public void logAllTransactions()
        {
            foreach (TransactionInfo inf in transactionList)
            {
                System.Console.WriteLine(inf.ToString());
            }
        }
        public decimal maximum { get; set; }
        private List<TransactionInfo> transactionList;
    }
}
