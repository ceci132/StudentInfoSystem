using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UserLogin
{
    public static class UserData
    {
        static private List<User> _testUsers;
        public static List<User> TestUsers
        {
            get {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        public static void prepareCertificate(String username, String fileName)
        {
            foreach (User user in TestUsers)
            {
                if (username.Equals(user.username) && user.role == 4)
                {
                    String certificate = user.username + " with faculty number: " + user.facultyNumber +
                        " is studying CSE in his last year.";
                    File.WriteAllText(fileName + ".txt", certificate);
                    Logger.LogActivity("Preparing certificate for " + username);
                    return;
                }
            }
            Logger.LogActivity("User not found in the database while preparing a certificate.");
            Console.WriteLine("The given user is not a student or is not part of the database, hence can not have certificate");
        }
        public static void printAllUsers()
        {
            foreach (User user in TestUsers)
            {
                Console.WriteLine("Username:\t" + user.username + "\nPassword:\t" + user.password +
                    "\nRole:\t\t" + (UserRoles)user.role + "\nFaculty number:\t" + user.facultyNumber +
                    "\nAccount expiricy date:\t" + user.validToDate);
            }
        }
        public static void AssignUserRole(String username, UserRoles newRole)
        {
            foreach (User user in TestUsers)
            {
                if (username.Equals(user.username))
                {
                    user.role = Convert.ToInt32(newRole);
                    Logger.LogActivity("Change role to: " + newRole);
                }
            }
        }
        public static void SetUserActiveTo(String username, DateTime newDateTime)
        {
            foreach (User user in TestUsers)
            {
                if (username.Equals(user.username))
                {
                    user.validToDate = newDateTime;
                    Logger.LogActivity("Change of expiricy to: " + newDateTime);
                }
            }
        }
        static public User IsUserPassCorrect(String username, String password)
        {
            List<User> users = (from user in TestUsers
                                  where username.Equals(user.username) && password.Equals(user.password)
                                  select user).ToList();
            return users.FirstOrDefault();
        }
        static private void ResetTestUserData()
        {
            if(_testUsers == null)
            {
                _testUsers = new List<User>();
                User dummyUser = new User();
                dummyUser.username = "admin";
                dummyUser.password = "123456";
                dummyUser.facultyNumber = "121219";
                dummyUser.role = 1;
                dummyUser.created = DateTime.Now;
                dummyUser.validToDate = DateTime.MaxValue;
                _testUsers.Add(dummyUser);

                dummyUser = new User();
                dummyUser.username = "Martin";
                dummyUser.password = "654321";
                dummyUser.facultyNumber = "121218";
                dummyUser.role = 4;
                dummyUser.created = DateTime.Now;
                dummyUser.validToDate = DateTime.MaxValue;
                _testUsers.Add(dummyUser);

                dummyUser = new User();
                dummyUser.username = "Ivan";
                dummyUser.password = "193756";
                dummyUser.facultyNumber = "121217";
                dummyUser.role = 4;
                dummyUser.created = DateTime.Now;
                dummyUser.validToDate = DateTime.MaxValue;
                _testUsers.Add(dummyUser);

                dummyUser = new User();
                dummyUser.username = "ivan";
                dummyUser.password = "123456";
                dummyUser.facultyNumber = "1";
                dummyUser.role = (int)UserRoles.INSPECTOR;
                dummyUser.created = DateTime.Now;
                dummyUser.validToDate = DateTime.MaxValue;
                _testUsers.Add(dummyUser);
            }
        }
    }
}
