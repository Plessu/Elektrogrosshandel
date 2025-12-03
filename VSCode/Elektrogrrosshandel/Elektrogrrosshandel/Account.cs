using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
{


    internal class Account
    {
        private int AccountID { get; set; }
        private string UserName { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string FirmName { get; set; }
        private int PasswordHash { get; set; }
        private string Email { get; set; }
        private string PhoneNumber { get; set; }
        private DateTime CreatedAt { get; set; }
        private string AcountRole { get; set; }
        private int SerialCode { get; set; }
        private bool IsFirmAccount { get; set; }
        private bool WantUSTax { get; set; }
        private Bucket ActiveBucket { get; set; }
        private List<Bucket> SafedBuckets {get; set; }

        private static List<Account> Accounts = new List<Account>();
        private static List<int> UsedAccountIDs = new List<int>();

        private void CreateAccount(int accountID, string username, string firstName, string lastName, string firmName,
                 string password, string email, string phoneNumber, string acountRole, int serialCode, bool isFirmAccount)
        {
            this.AccountID = accountID;
            this.UserName = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FirmName = firmName;
            this.PasswordHash = HashCode.Combine(password);
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.CreatedAt = DateTime.Now;
            this.AcountRole = acountRole;
            this.SerialCode = serialCode;
            this.CreatedAt = DateTime.Now;
            this.IsFirmAccount = isFirmAccount;
            this.ActiveBucket = Bucket.CreateBucket(accountID, "Active Bucket");
            this.SafedBuckets = new List<Bucket>(10);

            AddAccountToList();

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
            //CreateAccount(AccountName, FirmName, Password, Email, role, SerialCode);
        }
        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Username: {UserName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Account Role: {AcountRole}");
            Console.WriteLine($"Created At: {CreatedAt}");
        }
    }
}
