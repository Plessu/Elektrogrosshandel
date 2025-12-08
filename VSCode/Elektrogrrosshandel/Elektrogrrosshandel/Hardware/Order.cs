using Elektrogrosshandel;
using Elektrogrosshandel.User;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Globalization;

namespace Elektrogrosshandel.Hardware
{
    internal class Order
    {
        private int OrderID { get; set; }
        private double OrderTotalPrice { get; set; }
        private int AccountID { get; set; }
        private string OrderName { get; set; }
        private DateTime OrderDate { get; set; }
        private Bucket OrderBucket { get; set; }

        private static List<int> UsedIDs = new List<int>();

        private Order CreateOrder(int orderID, string orderName)
        {
            OrderID = orderID;
            OrderTotalPrice = Bucket.GetBucketValue(Account.GetActiveBucketOfAccount(Program.ActiveUser));
            AccountID = Account.GetAccountID(Program.ActiveUser);
            OrderName = orderName;
            OrderDate = DateTime.Now;
            OrderBucket = Account.GetActiveBucketOfAccount(Program.ActiveUser);

            return this; 
        }

        public static Order PlaceOrder(string orderName)
        {
            Random rnd = new Random();
            int newOrderID;

            do
            {
                newOrderID = rnd.Next(100000, 999999);

            } while (UsedIDs.Contains(newOrderID));

            UsedIDs.Add(newOrderID);
            Order newOrder = new Order();
            newOrder.CreateOrder(newOrderID, orderName);

            return newOrder;
        }

        public static Markup GetOrdersInfo(Order order)
        {
            Markup orderInfo = new Markup($"[bold yellow]Order ID:[/] {order.OrderID} | [bold yellow]Order Name:[/] {order.OrderName} | [bold yellow]Order Total Price:[/] {order.OrderTotalPrice.ToString("C", CultureInfo.CreateSpecificCulture("de-DE"))} | [bold yellow]Order Date:[/] {order.OrderDate.ToString("g")}");

            return orderInfo;
        }
    }
}
