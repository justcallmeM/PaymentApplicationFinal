﻿using System;
using System.Collections.Generic;

namespace Application
{
    class UniqueTransaction
    {
        public DateTime uniqueDate;
        public string uniqueMerchantName;
        
        public void UniquenessCheck(DateTime date, string merchantName, List<UniqueTransaction> uniqueTransactionList)
        {
            uniqueDate = date;
            uniqueMerchantName = merchantName;

            foreach (var transaction in uniqueTransactionList)
            {
                if (transaction.uniqueDate.Month == date.Month && transaction.uniqueMerchantName == merchantName)
                {
                    uniqueDate = DateTime.MinValue;
                    uniqueMerchantName = String.Empty;
                    break;
                }
            }
        }
    }
}
