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
            string filePath = "transactions.txt";
            var lineCount = File.ReadLines(filePath).Count();
            int counter = 0;
            List<Tuple<DateTime,string>> uniqueTransactions = new List<Tuple<DateTime, string>>();

            //Program starts.
            //Sorting the data inside the .txt file.
            //Also a possibility to ignore spaces.
            SortByDate(filePath);

            //While loop to output transaction fee as soon as it processes the transaction.
            while (lineCount > counter)
            {
                //Dividing the .txt file into three different parts (Date | Merchant | Amount)
                var data = DataSeparation(filePath, counter);

                //First step - look at the merchant, the payment and apply the discount accordingly.
                double transactionAfterDiscount = DiscountProcess(data.Item2, data.Item3);
                
                //Adding unique transactions into the list
                uniqueTransactions.Add(UniquenessCheck(data.Item1, data.Item2, uniqueTransactions));

                //Deciding whether the merchant needs an invoice fee or not.
                int invoiceFee = InvoiceFeeDetermination(uniqueTransactions, data.Item1, data.Item2);

                //Calculating the total fee. 1% + invoice fee.
                double fee = FeeCalculation(transactionAfterDiscount, invoiceFee);

                //Writing out the result line.
                Console.WriteLine(String.Format("{0:yyyy-MM-dd}",data.Item1) + " " + data.Item2 + ": " + String.Format("{0:0.00}", fee));
                
                //Count required to read the following line.
                counter++;
            }

            Console.ReadKey(true);
        }

        //Sort the file in ASC. (Starting with Date, then names and values).
        //Remove empty strings from the file.
        static void SortByDate(string filePath)
        {
            string[] contents = File.ReadAllLines(filePath);

            //Use when there are empty lines inside the file.
            //Will be required to run the code twice. (Will be fixed)
            /*string stringToRemove = String.Empty;
            contents = contents.Where(val => val != stringToRemove).ToArray();*/

            var sorted = contents.OrderBy(i => i);

            File.WriteAllLines(filePath, sorted);
        }

        //Logic responsible for separating the read transaction into three separate data fields.
        public static Tuple<DateTime, string, double> DataSeparation(string data, int number)
        {
            DateTime date = new DateTime();
            string merchantName = string.Empty;
            double transaction = 0;

            string dataLine = File.ReadLines(data).ElementAt(number);
            
            string[] eachLineArray = dataLine.Split(' ');

            string[] dateArray = eachLineArray[0].Split('-');
            Int32.TryParse(dateArray[0], out int year);
            Int32.TryParse(dateArray[1], out int month);
            Int32.TryParse(dateArray[2], out int day);
            date = new DateTime(year, month, day);

            merchantName = eachLineArray[1];

            double.TryParse(eachLineArray[2], out double transactionEntry);
            transaction = transactionEntry;

            return new Tuple<DateTime, string, double>(date, merchantName, transaction);
        }

        //Logic responsible for applying the discounts.
        public static double DiscountProcess(string merchant, double transaction)
        {
            double discount = 0;
            double transactionAfterDiscount = 0;

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

        //Logic responsible for providing the unique transaction line
        //unique transaction - each month every merchant is considered UNIQUE only once. 
        static Tuple<DateTime,string> UniquenessCheck(DateTime time, string merchant, List<Tuple<DateTime, string>> uniqueList)
        {
            DateTime uniqueTime = time;
            string uniqueString = merchant;

            foreach(var tuple in uniqueList)
            {
                if(tuple.Item1.Month == time.Month && tuple.Item2 == merchant)
                {
                    uniqueTime = new DateTime(0001,01,01);
                    uniqueString = String.Empty;
                    break;
                }
            }

            return new Tuple<DateTime, string>(uniqueTime, uniqueString);
        }

        //If the unique list contains the read entry, then it receives a 29 DKK fee.
        public static int InvoiceFeeDetermination(List<Tuple<DateTime,string>> uniqueTransactions, DateTime originalTime, string originalMerchant)
        {
            int fee = 0;

            foreach(var tuple in uniqueTransactions)
            {
                if((originalTime == tuple.Item1) && (tuple.Item2 == originalMerchant))
                {
                    fee = 29;
                    break;
                }
            }

            return fee;
        }

        //Logic responsible for the fee.
        public static double FeeCalculation(double transaction, int invoiceFee)
        {
            double fee = 0;
            return fee = transaction / 100 + invoiceFee;
        }
    }
}
