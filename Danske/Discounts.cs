namespace Application
{
    class Discounting
    {
        public decimal DiscountProcess(string merchant, decimal transaction)
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
    }
}
