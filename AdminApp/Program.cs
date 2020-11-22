using System;
using Library;

namespace AdminApp
{
    class Program
    {
        public static bool Running = false;
        public static bool IsAdmin = false;
        public static string UserId;
        static void Main(string[] args)
        {
            HandleList.ReadFromFile();
            LogIn();
            while(Running)
            {
                PrintMainMenu();
            }
        }
        static void LogIn()
        {
            bool logIn = false;
            while(!logIn)
            {
                Console.Clear();
                Console.WriteLine($"-- Log into Adminapplication -- Current user: {UserId}");
                Console.WriteLine("Enter ID: ");
                string tmpId = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string tmpPassword = Console.ReadLine();
                logIn = HandleList.AdminLogIn(tmpId, tmpPassword);
                if(logIn)
                {
                    Console.WriteLine("ID and Password correct. Press any key to continue to menu.");
                    Running = true;
                    IsAdmin = true;
                    UserId = tmpId;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Something went wrong. Id or password incorrect or user might not have Adminright. Press any key to try again.");
                    Console.ReadKey();
                }
            }
          
        }
        static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("ADMIN Mainmenu");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("1. Add new employee");
            Console.WriteLine("2. Remove an employee");
            Console.WriteLine("3. Show all employees");
            Console.WriteLine("4. Edit an employee");
            Console.WriteLine("5. Save employeelist to file");
            int input = Verify.StringToInt(Console.ReadLine());
            switch(input)
            {
                case 1:
                    HandleList.AddNewEmployee();
                    Console.WriteLine("Added new employee..");
                    Console.ReadKey();
                    break;
                case 2:
                    HandleList.RemoveEmploye();
                    break;
                case 3:
                    HandleList.ShowEmployeesForAdmin();
                    Console.ReadKey();
                    break;
                case 4:
                    UserId = HandleList.EditEmployee(IsAdmin, UserId);
                    break;
                case 5:
                    HandleList.SaveListToFile();
                    Console.WriteLine("Employeelist saved. Press any key to continue.");
                    Console.ReadKey();
                    break;
                case 0:
                    Console.WriteLine("Exit program....");
                    Console.ReadKey();
                    Running = false;
                    break;

            }
        }
    }

    
}
