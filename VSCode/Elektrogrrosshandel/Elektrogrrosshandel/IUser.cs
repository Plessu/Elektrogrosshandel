using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
{
    internal interface IUser
    {
        string Username { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int PasswordHash { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        DateTime CreatedAt { get; set; }
        string UserRole { get; set; }

        bool AllowNameChange { get; set; }
        bool AllowEmailChange { get; set; }
        bool AllowPasswordChange { get; set; }
        bool AllowPhoneNumberChange { get; set; }
        bool AllowRoleChange { get; set; }
        bool AllowUserDeletion { get; set; }


        public void CreateUser(
            string userName, string firstName, string lastName, string password, string email, 
            string phoneNumber, string userRole, bool[] allowFlags);
        public void DeleteUser(string userName);
        public void UpdateUser(
            string userName, string firstName, string lastName, string password, string email,
            string phoneNumber, string userRole, bool[] allowFlags);
    }
}
