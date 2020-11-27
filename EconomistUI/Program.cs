using System;
using Library;
namespace EconomistUI
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
            while (Running)
            {
                PrintMainMenu();
            }
        }
        static void LogIn()
        {
            bool logIn = false;
            while (!logIn)
            {
                Console.Clear();
                Console.WriteLine("-- Log into Economistapplication --");
                Console.WriteLine("Enter ID: ");
                string tmpId = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string tmpPassword = Console.ReadLine();
                logIn = HandleList.EcomomistLogIn(tmpId, tmpPassword);
                if (logIn)
                {
                    Console.WriteLine("ID and Password correct. Press any key to continue to menu.");
                    Running = true;
                    UserId = tmpId;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Something went wrong. Id or password incorrect or user might not have Economistright. Press any key to try again.");
                    Console.ReadKey();
                }
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
            Console.WriteLine("4. Edit employee salary");
            Console.WriteLine("5. Save your changes.");
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
                    HandleList.ShowEmployeesForEconomist();
                    break;
                case 4:
                    HandleList.EditEmployee(IsAdmin, UserId);
                    break;
                case 5:
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
    }
}
