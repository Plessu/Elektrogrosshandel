using Elektrogrosshandel;
using Elektrogrosshandel.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.Hardware
{
    internal class Order
    {
        private int OrderID {get; set; }
        private double OrderTotalPrice { get; set; }
        private int AccountID {get; set; }
        private string OrderName {get; set; }
        private DateTime OrderDate { get; set; }
        private Bucket OrderBucket { get; set; }

        public Order (int orderID, string orderName)
        {
            OrderID = orderID;
            OrderTotalPrice = Bucket.GetBucketValue(Account.GetActiveBucketOfAccount(Program.ActiveUser));
            AccountID = Account.GetAccountID(Program.ActiveUser);
            OrderName = orderName;
            OrderDate = DateTime.Now;
            OrderBucket = Account.GetActiveBucketOfAccount(Program.ActiveUser);
        }


    }
}
