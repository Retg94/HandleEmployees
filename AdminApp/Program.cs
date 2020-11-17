using System;
using Library;

namespace EmployeeApp
{
    class Program
    {
        public static bool Running = true;
        static void Main(string[] args)
        {
         
            while(Running)
            PrintMainMenu();
        }
        static void PrintMainMenu()
            {
                Console.Clear();
                Console.WriteLine("ADMIN Mainmenu");
                Console.WriteLine("0. Exit.");
                Console.WriteLine("1. Add new employee");
                int input = Verify.StringToInt(Console.ReadLine());
                switch(input)
                {
                    case 1:
                        Console.WriteLine("Adding new employee.");
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
