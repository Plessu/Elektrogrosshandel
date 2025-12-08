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

            if (Account.GetWantUSTax(Program.ActiveUser) == false)
            {
                OrderTotalPrice = Bucket.GetBucketValue(Account.GetActiveBucketOfAccount(Program.ActiveUser)) / 119 * 100;
            }
            else
            {
                OrderTotalPrice = Bucket.GetBucketValue(Account.GetActiveBucketOfAccount(Program.ActiveUser));
            }
            
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

        public static Markup GetDetailedOrderInfoByOrder(Order Order)
        {
            Markup detailedOrderInfo = new Markup($"[bold yellow]Order ID:[/] {Order.OrderID}\n[bold yellow]Order Name:[/] {Order.OrderName}\n[bold yellow]Order Total Price:[/] {Order.OrderTotalPrice.ToString("C", CultureInfo.CreateSpecificCulture("de-DE"))}\n[bold yellow]Order Date:[/] {Order.OrderDate.ToString("f")}\n\n[bold yellow]Ordered Items:[/]\n{Bucket.GetArticelsInBucket(Order.OrderBucket)}");
            return detailedOrderInfo;
        }

        public static int GetOrderID(Order order)
        {
            return order.OrderID;
        }
    }
}
