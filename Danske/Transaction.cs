using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Transaction
    {
        public DateTime date = new DateTime();
        public string merchantName = string.Empty;
        public decimal transaction = 0;

        public void DataSeparation(string[] content, int number)
        {
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
        }
    }
}
