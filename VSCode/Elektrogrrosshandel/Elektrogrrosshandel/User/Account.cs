using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.IO;
using Elektrogrosshandel.Functions;
using Elektrogrosshandel.User;
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


        private static List<Account> Accounts = new List<Account>();
        private static List<int> UsedAccountIDs = new List<int>();



        private void CreateAccount(int accountID, string userName, string firstName, string lastName, string firmName,
                 string passwordHash, byte[] passwordSalt, string email, string phoneNumber, string acountRole, int serialCode,
                 bool isFirmAccount, bool wantUSTax)
        {
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
            this.AcountRole = acountRole;
            this.SerialCode = serialCode;
            this.CreatedAt = DateTime.Now;
            this.IsFirmAccount = isFirmAccount;
            this.WantUSTax = wantUSTax;
            this.ActiveBucket = Bucket.CreateBucket(accountID, "Active Bucket");
            this.SafedBuckets = new List<Bucket>();

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
                 string password, string email, string phoneNumber, int serialCode)
        {

            string accountRole = VerifyAccount(SerialCode);
            int accountID = CreateUserID();
            bool isFirmAccount;
            bool wantUSTax;
            byte[] passwordSalt = new byte[64];

            string passwordHash = PasswordHelper.HashPassword(password, out passwordSalt);


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
                 passwordHash, passwordSalt, email, phoneNumber, accountRole, serialCode,
                 isFirmAccount, wantUSTax);

            AddAccountToList(account);

            return account;
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

        public static void TestData()
        {
            Account testAccount = new Account();
            testAccount.newAccount("a", "Giacomo", "Graef", "Graef Enterprise", "a", "g.graef@graef.graef", "0123/12adbe", 2);


        }

    }
}
