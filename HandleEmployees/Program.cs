using System;
using Library;

namespace EmployeeApp
{
    class Program
    {
        public static bool Running = false;
        public static string UserId;
        public static bool IsAdmin = false;
        static void Main(string[] args)
        {
            HandleList.ReadFromFile();
            LogIn();
            while(Running)
            {
                PrintMainMenu();
            }
        }
        static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"EMPLOYEE Mainmenu -- Current user: {UserId}");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("1. See my own information");
            Console.WriteLine("2. Edit my information");
            Console.WriteLine("3. Show all employees");
            Console.WriteLine("4. Save your changes.");
            int input = Verify.StringToInt(Console.ReadLine());
            switch (input)
            {
                case 1:
                    HandleList.ShowOwnInfo(UserId);
                    break;
                case 2:
                    UserId = HandleList.EditOwnInfo(UserId, IsAdmin);
                    break;
                case 3:
                    HandleList.ShowEmployeesForEmployee();
                    break;
                case 4:
                    HandleList.SaveListToFile();
                    Console.WriteLine("Your changes have been saved.");
                    HandleList.PressAnyKeyToContinue();
                    break;
                case 0:
                    Console.WriteLine("Exit program....");
                    HandleList.PressAnyKeyToContinue();
                    Running = false;
                    break;

            }
        }
        static void LogIn()
        {
            bool logIn = false;
            while (!logIn)
            {
                Console.Clear();
                Console.WriteLine("-- Log into EmployeeApp --");
                Console.WriteLine("Enter ID: ");
                UserId = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string tmpPassword = Console.ReadLine();
                logIn = HandleList.EmployeeLogIn(UserId, tmpPassword);
                if (logIn)
                {
                    Console.WriteLine("ID and Password correct. Press any key to continue to menu.");
                    Running = true;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Something went wrong. Id or password incorrect. Press any key to try again.");
                    Console.ReadKey();
                }
            }

        }
    }
}
