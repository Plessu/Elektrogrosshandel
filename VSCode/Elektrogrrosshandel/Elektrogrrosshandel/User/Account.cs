using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.IO;
using Elektrogrosshandel.Functions;
using Elektrogrosshandel.User;
using Elektrogrosshandel.Hardware;
using Spectre.Console;

namespace Elektrogrosshandel
{
    internal class Account
    {
        private int AccountID { get; set; }
        private string UserName { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string FirmName { get; set; }
        private string Password { get; set; }
        private byte[] PasswordSalt { get; set; }
        private string Email { get; set; }
        private string PhoneNumber { get; set; }
        private DateTime CreatedAt { get; set; }
        private string AcountRole { get; set; }
        private int SerialCode { get; set; }
        private bool IsFirmAccount { get; set; }
        private bool WantUSTax { get; set; }
        private Bucket ActiveBucket { get; set; }
        private List<Bucket> SafedBuckets { get; set; }
        private List<Markup> AccountInformation { get; set; }
       private List<Order> Orders { get; set; }


        private static List<Account> Accounts = new List<Account>();
        private static List<int> UsedAccountIDs = new List<int>();



        public void CreateAccount(string userName, string firstName, string lastName, string firmName,
                 string password, string email, string phoneNumber, int serialCode)
        {
            string acountRole = VerifyAccount(serialCode);
            int accountID = CreateUserID();
            bool isFirmAccount;
            bool wantUSTax;
            byte[] passwordSalt = new byte[64];

            string passwordHash = PasswordHelper.HashPassword(password, out passwordSalt);


            if (VerifyAccount(serialCode) == "Admin" || VerifyAccount(serialCode) == "PrivateUser")
            {
                isFirmAccount = false;
                wantUSTax = false;
            }
            else
            {
                isFirmAccount = true;
                wantUSTax = true;
            }

            this.AccountID = accountID;
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FirmName = firmName;
            this.Password = passwordHash;
            this.PasswordSalt = passwordSalt;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.CreatedAt = DateTime.Now;
            this.AcountRole = VerifyAccount(serialCode);
            this.SerialCode = serialCode;
            this.CreatedAt = DateTime.Now;
            this.IsFirmAccount = isFirmAccount;
            this.WantUSTax = wantUSTax;
            this.ActiveBucket = Bucket.CreateBucket(accountID, "Active Bucket");
            this.SafedBuckets = new List<Bucket>();
            this.Orders = new List<Order>();

            List<Markup> accountInformation = new List<Markup>
            {
                new Markup($"FirstName: {firstName}"),
                new Markup($"LastName: {lastName}"),
                new Markup($"FirmName: {firmName}"),
                new Markup($"Email: {email}"),
                new Markup($"PhoneNumber: {phoneNumber}"),
                new Markup($"\nAccountID: {accountID}"),
                new Markup($"AcountRole: {acountRole}"),
                new Markup($"UserName: {userName}"),
                new Markup($"CreatedAt: {DateTime.Now}")

            };

            this.AccountInformation = accountInformation;

            AddAccountToList(this);

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


        public static byte[] GetAccountSalt(string userName)
        {
            foreach (Account account in Accounts)
            {
                if (account.UserName == userName)
                {
                    return account.PasswordSalt;
                }
            }
            return null;
        }

        public static string GetAccountPasswordHash(string userName)
        {
            foreach (Account account in Accounts)
            {
                if (account.UserName == userName)
                {
                    return account.Password;
                }
            }
            return null;
        }

        public static bool GetWantUSTax(Account account)
        {
            return account.WantUSTax;
        }

        public static bool DoesAccountExist(string userName)
        {
            foreach (Account account in Accounts)
            {
                if (account.UserName == userName)
                {
                    return true;
                }
            }
            return false;
        }

        public static void ChangeAccountFirstName(Account account, string newFirstName)
        {
            account.FirstName = newFirstName;
        }

        public static void ChangeAccountLastName(Account account, string newLastName)
        {
            account.LastName = newLastName;
        }

        public static void ChangeAccountEmail(Account account, string newEmail)
        {
            account.Email = newEmail;
        }

        public static void ChangeAccountPhoneNumber(Account account, string newPhoneNumber)
        {
            account.PhoneNumber = newPhoneNumber;
        }

        public static string GetAccountNameByAccount(Account account)
        {
            return account.FirstName + " " + account.LastName;
        }

        public static Account GetAccountByUserName(string userName)
        {
            foreach (Account account in Accounts)
            {
                if (account.UserName == userName)
                {
                    return account;
                }
            }
            return null;
        }

        public static List<Markup> GetAccountInformationList(Account account)
        {
            return account.AccountInformation;
        }

        public static Bucket GetActiveBucket(Account account)
        {
            return account.ActiveBucket;
        }

        public static void SaveCurrentBucket(string bucketName)
        {
            Bucket currentBucket = Program.ActiveUser.ActiveBucket;
            Bucket.ChangeBucketName(currentBucket, bucketName);
            Program.ActiveUser.SafedBuckets.Add(currentBucket);
            Program.ActiveUser.ActiveBucket = Bucket.CreateBucket(Program.ActiveUser.AccountID, "Active Bucket");
            return;
        }

        public static bool LoadSavedBucket(int bucketID)
        {
            foreach (Bucket bucket in Program.ActiveUser.SafedBuckets)
            {
                if (bucket.BucketID == bucketID)
                {
                    Program.ActiveUser.ActiveBucket = bucket;

                    return true;
                }
            }

            return false;
        }

        public static bool DeleteSavedBucket(int bucketID)
        {
            foreach (Bucket bucket in Program.ActiveUser.SafedBuckets)
            {
                if (bucket.BucketID == bucketID)
                {
                    Program.ActiveUser.SafedBuckets.Remove(bucket);
                    return true;
                }
            }
            return false;
        }

        public static List<Markup> GetSafedBuckets(Account account)
        {
            List<Markup> bucketInfo = new List<Markup>(0);

            if (account.SafedBuckets.Count == 0)
            {
                bucketInfo.Add(new Markup("No saved buckets found."));
            }

            foreach (Bucket bucket in account.SafedBuckets)
            {
                bucketInfo.Add(bucket.GetBucketInformation());

                return bucketInfo;
            }

            return bucketInfo;
        }

        public static Bucket GetActiveBucketOfAccount(Account account)
        {
            return account.ActiveBucket;
        }

        public static int GetAccountID(Account account)
        {
            return account.AccountID;
        }

        public static void AddOrderToAccount(Account account, Order order)
        {
            account.Orders.Add(order);
        }

        public static Order GetOrderByOrderID(Account account, int orderID)
        {
            foreach (Order order in account.Orders)
            {
                if (orderID == Order.GetOrderID(order))
                {
                    return order;
                }
            }
            return null;
        }

        public static List<Order> GetAccountOrders(Account account)
        {
            return account.Orders;
        }

        public static string GetAccountRole(Account account)
        {
            return account.AcountRole;
        }

        public static List<Account> GetAllAccounts()
        {
            return Accounts;
        }


        public static void TestData()
        {
            Account testAccount = new Account();
            testAccount.CreateAccount("a", "Giacomo", "Graef", "Graef Enterprise", "a", "g.graef@graef.graef", "0123/12adbe", 2);
            
            Account testAccount2 = new Account();
            testAccount2.CreateAccount("b", "Max", "Mustermann", "Mustermann GmbH", "b", "maxmuster@muster.de", "0987/65gfedc", 9);

            Account testAccount3 = new Account();
            testAccount3.CreateAccount("c", "Erika", "Mustermann", "", "c", "Erika@Erika.de", "0111/223344", 5);
        }

    }
}
