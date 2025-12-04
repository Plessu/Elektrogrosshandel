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
        private HashCode PasswordHash { get; set; }
        private int PasswordSalt { get; set; }
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
                 HashCode password, int passwordSalt, string email, string phoneNumber, string acountRole, int serialCode,
                 bool isFirmAccount, bool wantUSTax)
        {
            this.AccountID = accountID;
            this.UserName = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FirmName = firmName;
            this.PasswordHash = password;
            this.PasswordSalt = passwordSalt;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.CreatedAt = DateTime.Now;
            this.AcountRole = acountRole;
            this.SerialCode = serialCode;
            this.CreatedAt = DateTime.Now;
            this.IsFirmAccount = isFirmAccount;
            this.WantUSTax = wantUSTax;
            this.ActiveBucket = Bucket.CreateBucket(accountID, "Active Bucket");
            this.SafedBuckets = new List<Bucket>(10);

        }
        private void AddAccountToList(Account account)
        {
            Accounts.Add(account);
        }
        private string VerifyAccount(int SerialCode)
        {
            if (SerialCode % 2 == 0)
            {
                return "Admin";
            }
            else if (SerialCode % 3 == 0)
            {
                return "BuisnessUser";
            }
            return "PrivateUser";
        }
        private int CreateUserID()
        {
            Random rnd = new Random();
            int iD = 0;

            do
            {
                iD = rnd.Next(1000, 9999);
                if (UsedAccountIDs.Contains(iD))
                {
                    continue;
                }
                else
                {
                    UsedAccountIDs.Add(iD);
                    return iD;
                }

            } while (true);

        }

        public Account newAccount(string username, string firstName, string lastName, string firmName,
                 HashCode password, int passwordSalt, string email, string phoneNumber, int serialCode)
        {
            string accountRole = VerifyAccount(SerialCode);
            int accountID = CreateUserID();
            bool isFirmAccount;
            bool wantUSTax;


            if (accountRole == "Admin" || accountRole == "PrivateUser")
            {
                isFirmAccount = false;
                wantUSTax = false;
            }
            else
            {
                isFirmAccount = true;
                wantUSTax = true;
            }

            Account account = new Account();

            account.CreateAccount(accountID, username, firstName, lastName, firmName,
                 password, passwordSalt, email, phoneNumber, accountRole, serialCode,
                 isFirmAccount, wantUSTax);

            AddAccountToList(account);

            return account;
        }
    }
}
