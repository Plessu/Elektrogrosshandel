using Elektrogrosshandel;
using Elektrogrosshandel.User;
using Elektrogrosshandel.Hardware;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_AccountOrdersSelected
    {

        private static Layout AccountOrders(Order Order)
        {
            Layout accountMenu = new Layout("AccountMenuOrderDisplay");
                        

            accountMenu["AccountMenuOrderDisplay"].Update(DisplayOrder(Order));


            return accountMenu;
        }

        private static Panel DisplayOrder(Order Order)
        {
            Markup orderLines;
            orderLines = Order.GetDetailedOrderInfoByOrder(Order);

            var orderPanel = new Panel(orderLines)
            {
                Header = new PanelHeader("[bold #af8700 on black]Order Details[/]", Justify.Center),
                Height = 15,
                Width = 35,
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1),
                Expand = true
            };

            return orderPanel;
        }

        public static Layout DisplayDetailedOrderInfo(Order order)
        {
            return AccountOrders(order);
        }
    }
}
