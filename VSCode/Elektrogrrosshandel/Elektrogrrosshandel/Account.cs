using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
{


    internal class Account
    {
        private string AccountName { get; set; }
        private string FirmName { get; set; }
        private int PasswordHash { get; set; }
        private string Email { get; set; }
        private string PhoneNumber { get; set; }
        private DateTime CreatedAt { get; set; }
        private string AcountRole { get; set; }
        private int SerialCode { get; set; }
        private List<User> UsersRealated { get; set; }
        bool WantUSTax { get; set; }

        private static List<Account> Accounts = new List<Account>();

        private void CreateAccount(string Accountname, string FirmName, string Password, string Email, string PhoneNumber, string AcountRole, int SerialCode)
        {
            this.AccountName = Accountname;
            this.FirmName = FirmName;
            this.PasswordHash = HashCode.Combine(Password);
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.CreatedAt = DateTime.Now;
            this.AcountRole = AcountRole;
            this.SerialCode = SerialCode;
            AddAccountToList();

            if (AcountRole == "PrivateUser")
            {
                UsersRealated = new List<Users>(1);
            }
            else if (AcountRole == "BuisnessUser")
            {
                UsersRealated = new List<Users>(10);
            }
            else if (AcountRole == "Admin")
            {
                UsersRealated= new List<Users>(1);
            }
        }
        private void AddAccountToList()
        {
            Accounts.Add(this);
        }
        private string VerifyAccount(int SerialCode)
        {
            if (SerialCode % 2 == 0)
            {
                return "Admin";
            }
            if (SerialCode % 3 == 0)
            {
                return "Moderator";
            }
            return "PrivateUser";
        }

        public Account(string AccountName, string FirmName, string Password, string Email, int SerialCode)
        {
            string role = VerifyAccount(SerialCode);
            CreateAccount(AccountName, FirmName, Password, Email, role, SerialCode);
        }
        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Username: {AccountName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Account Role: {AcountRole}");
            Console.WriteLine($"Created At: {CreatedAt}");
        }
    }
}
