using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    class Program
    {
        public static void errorMessage(String message)
        {
            Console.WriteLine("Error message is: " + message);
        }
        private static void menu()
        {
            Console.WriteLine("Choose option:\n0:\tExit\n1:\tChange user role\n2:\tChange user expiricy\n3:\tList of users\n4:\tLog activity" +
            "\n5:\tCurrent log activity\n6:\tCertificate user");
            int menuOption = Convert.ToInt32(Console.ReadLine());
            switch (menuOption)
            {
                case 0:
                    Console.WriteLine("Terminating...");
                    break;
                case 1:
                    Console.WriteLine("Enter username:");
                    String username1 = Console.ReadLine();
                    Console.WriteLine("Enter new role:");
                    UserRoles userRole1 = (UserRoles)Enum.Parse(typeof(UserRoles), Console.ReadLine().ToUpper());
                    UserData.AssignUserRole(username1, userRole1);
                    break;
                case 2:
                    Console.WriteLine("Enter username:");
                    String username2 = Console.ReadLine();
                    Console.WriteLine("Enter new expiracy date:");
                    DateTime date2 = DateTime.Parse(Console.ReadLine());
                    UserData.SetUserActiveTo(username2, date2);
                    break;
                case 3:
                    Console.WriteLine("List of all users:");
                    UserData.printAllUsers();
                    break;
                case 4:
                    Console.WriteLine("Log activity:");
                    IEnumerable<String> logs = Logger.showLogs();
                    foreach (string line in logs)
                    {
                        Console.WriteLine(line);
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter filter for current log:");
                    String filter = Console.ReadLine();
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> currentActs =
                    Logger.GetCurrentSessionActivities(filter);
                    foreach (string line in currentActs)
                    {
                        sb.Append(line);
                    }
                    break;
                case 6:
                    Console.WriteLine("Enter student:");
                    String user6 = Console.ReadLine();
                    Console.WriteLine("Enter file name:");
                    String fileName6 = Console.ReadLine();
                    UserData.prepareCertificate(user6, fileName6);
                    break;
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username: ");
            String inputUsername = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            String inputPassword= Console.ReadLine();
            LoginValidation loginValidation = new LoginValidation(inputUsername, inputPassword, new LoginValidation.ActionOnError(errorMessage));

            User user = null;
            bool result = loginValidation.ValidateUserInput(ref user);

            if (result && user.role != 1)
            {
                Console.WriteLine("Username: " + user.username + "\nPassword: " + user.password +
                    "\nFaculty number: " + user.facultyNumber + "\nRole: " + (UserRoles)user.role);
            }
            switch (LoginValidation.currentUserRole)
            {
                case UserRoles.ANONYMOUS:
                    Console.WriteLine(UserRoles.ANONYMOUS);
                    break;
                case UserRoles.ADMIN:
                    Console.WriteLine(UserRoles.ADMIN);
                    menu();
                    break;
                case UserRoles.INSPECTOR:
                    Console.WriteLine(UserRoles.INSPECTOR);
                    break;
                case UserRoles.PROFESSOR:
                    Console.WriteLine(UserRoles.PROFESSOR);
                    break;
                case UserRoles.STUDENT:
                    Console.WriteLine(UserRoles.STUDENT);
                    break;
            }
        }
    }
}
