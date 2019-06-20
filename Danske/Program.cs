using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    public class Program
    {
        //Knyga - "clean code".
        //abstract class, interface...
        static void Main()
        {
            string[] unsortedContents = File.ReadAllLines("transactions.txt");
            int lineCount = unsortedContents.Count();
            int counter = 0;
            List<Tuple<DateTime, string>> uniqueTransactions = new List<Tuple<DateTime, string>>();

            string[] content = SortByDate(unsortedContents);

            while (lineCount > counter)
            {
                var data = DataSeparation(content, counter);

                decimal transactionAfterDiscount = DiscountProcess(data.Item2, data.Item3);

                uniqueTransactions.Add(UniquenessCheck(data.Item1, data.Item2, uniqueTransactions));

                int invoiceFee = InvoiceFeeDetermination(uniqueTransactions, data.Item1, data.Item2);

                decimal fee = FeeCalculation(transactionAfterDiscount, invoiceFee);

                Console.WriteLine(String.Format("{0:yyyy-MM-dd}", data.Item1) + " " + data.Item2 + ": " + String.Format("{0:0.00}", fee));

                counter++;
            }

            Console.ReadKey(true);
        }

        static string[] SortByDate(string[] contentsOfFile)
        {
            var sorted = contentsOfFile.OrderBy(i => i);
            string[] sortedFile = sorted.ToArray();

            return sortedFile;
        }

        public static Tuple<DateTime, string, decimal> DataSeparation(string[] content, int number)
        {
            DateTime date = new DateTime();
            string merchantName = string.Empty;
            decimal transaction = 0;

            string dataLine = content[number];

            string[] eachLineArray = dataLine.Split(' ');

            string[] dateArray = eachLineArray[0].Split('-');
            Int32.TryParse(dateArray[0], out int year);
            Int32.TryParse(dateArray[1], out int month);
            Int32.TryParse(dateArray[2], out int day);
            date = new DateTime(year, month, day);

            merchantName = eachLineArray[1];

            decimal.TryParse(eachLineArray[2], out decimal transactionEntry);
            transaction = transactionEntry;

            return new Tuple<DateTime, string, decimal>(date, merchantName, transaction);
        }

        public static decimal DiscountProcess(string merchant, decimal transaction)
        {
            int discount = 0;
            decimal transactionAfterDiscount = 0;

            switch (merchant)
            {
                case "TELIA":
                    discount = 10;
                    break;
                case "CIRCLE_K":
                    discount = 20;
                    break;
                default:
                    break;
            }

            transactionAfterDiscount = transaction - (transaction * discount / 100);

            return transactionAfterDiscount;
        }

        static Tuple<DateTime, string> UniquenessCheck(DateTime time, string merchant, List<Tuple<DateTime, string>> uniqueList)
        {
            DateTime uniqueTime = time;
            string uniqueString = merchant;

            foreach (var tuple in uniqueList)
            {
                if (tuple.Item1.Month == time.Month && tuple.Item2 == merchant)
                {
                    uniqueTime = new DateTime(0001, 01, 01);
                    uniqueString = String.Empty;
                    break;
                }
            }

            return new Tuple<DateTime, string>(uniqueTime, uniqueString);
        }

        public static int InvoiceFeeDetermination(List<Tuple<DateTime, string>> uniqueTransactions, DateTime originalTime, string originalMerchant)
        {
            int fee = 0;

            foreach (var tuple in uniqueTransactions)
            {
                if ((originalTime == tuple.Item1) && (tuple.Item2 == originalMerchant))
                {
                    fee = 29;
                    break;
                }
            }

            return fee;
        }

        public static decimal FeeCalculation(decimal transaction, int invoiceFee)
        {
            decimal fee = 0;
            return fee = transaction / 100 + invoiceFee;
        }
    }
}
