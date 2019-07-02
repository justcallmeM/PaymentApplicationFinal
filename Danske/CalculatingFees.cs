using System;
using System.Collections.Generic;

namespace Application
{
    class CalculatingFees
    {
        public int InvoiceFeeCalculation(List<UniqueTransaction> uniqueTransactions, DateTime originalTime, string originalMerchant)
        {
            int fee = 0;

            foreach (var transaction in uniqueTransactions)
            {
                if ((originalTime == transaction.uniqueDate) && (originalMerchant == transaction.uniqueMerchantName))
                {
                    fee = 29;
                    break;
                }
            }

            return fee;
        }

        public decimal TotalFeeCalculation(decimal transaction, int invoiceFee)
        {
            decimal fee = 0;
            return fee = transaction / 100 + invoiceFee;
        }
    }
}
