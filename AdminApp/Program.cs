using System;
using Library;

namespace EmployeeApp
{
    class Program
    {
        public static bool Running = false;
        static void Main(string[] args)
        {
            HandleEmployees.ReadFromFile();
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
                Console.WriteLine("-- Log into Adminapplication --");
                Console.WriteLine("Enter ID: ");
                string tmpId = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string tmpPassword = Console.ReadLine();
                logIn = HandleEmployees.AdminLogIn(tmpId, tmpPassword);
                if(logIn)
                {
                    Console.WriteLine("ID and Password correct. Press any key to continue to menu.");
                    Running = true;
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
            Console.WriteLine("2. Remove employee");
            Console.WriteLine("3. Show all employees");
            Console.WriteLine("4. Save employeelist to file");
            int input = Verify.StringToInt(Console.ReadLine());
            switch(input)
            {
                case 1:
                    HandleEmployees.AddNewEmployee();
                    Console.WriteLine("Added new employee..");
                    Console.ReadKey();
                    break;
                case 2:
                    HandleEmployees.RemoveEmploye();
                    break;
                case 3:
                    HandleEmployees.ShowEmployees();
                    Console.ReadKey();
                    break;
                case 4:
                    HandleEmployees.SaveListToFile();
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
