using Elektrogrosshandel.GUI;
using Elektrogrosshandel.GUI.GUI_Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.Functions
{
    internal class AccountMenu
    {
        public static void ShowAccountMenu()
        {
            int choice;

            AccountMenuInfo.ShowAccountInfo(out choice);
            MenuSelector(choice);
        }

        private static void MenuSelector(int choice)
        {
            int newChoice;

            switch (choice)
            {
                case 1:
                    AccountMenuInfo.ShowAccountInfo(out newChoice);
                    MenuSelector(newChoice);
                    break;
                case 2:
            }
        }
    }
}
