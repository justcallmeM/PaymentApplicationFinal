using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    public class Program
    {
        static void Main()
        {
            CalculatingFees calculatingFees = new CalculatingFees();
            Discounting discounting = new Discounting();
            Sorting sorting = new Sorting();
            Transaction transaction = new Transaction();
            UniqueTransaction uniqueTransaction;
            List<UniqueTransaction> uniqueTransactions = new List<UniqueTransaction>();

            string[] unsortedContent = File.ReadAllLines("transactions.txt");
            int lineCount = unsortedContent.Count();
            int counter = 0;

            string[] sortedContent = sorting.SortByDate(unsortedContent);

            while (lineCount > counter)
            {
                uniqueTransaction = new UniqueTransaction();

                transaction.DataSeparation(sortedContent, counter);

                decimal transactionAfterDiscount = discounting.DiscountProcess(transaction.merchantName, transaction.transaction);

                uniqueTransaction.UniquenessCheck(transaction.date, transaction.merchantName, uniqueTransactions);

                uniqueTransactions.Add(uniqueTransaction);

                int invoiceFee = calculatingFees.InvoiceFeeDetermination(uniqueTransactions, transaction.date, transaction.merchantName);

                decimal totalFee = calculatingFees.TotalFeeCalculation(transactionAfterDiscount, invoiceFee);

                Console.WriteLine(String.Format("{0:yyyy-MM-dd}", transaction.date) + " " + transaction.merchantName + ": " + String.Format("{0:0.00}", totalFee));

                counter++;
            }

            Console.ReadKey(true);
        }
    }
}
