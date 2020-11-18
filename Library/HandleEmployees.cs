using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Library
{
    public class HandleEmployees
    {
        public static List<Employee> ListOfEmployees = new List<Employee>();
        public static void AddNewEmployee()
        {
            Console.Clear();
            Console.WriteLine("-- ADDING NEW EMPLOYEE --");
            Console.WriteLine("Write new ID: ");
            string tmpId = Console.ReadLine();
            Console.WriteLine("Write new password: ");
            string tmpPassword = Console.ReadLine();
            Console.WriteLine("Write name of employee: ");
            string tmpName = Console.ReadLine();
            Console.WriteLine("Write adress of employee: ");
            string tmpAdress = Console.ReadLine();
            Console.WriteLine("Is this employee an Admin? Yes/No");
            string tmpAdmin = Console.ReadLine().ToLower();
            bool tmpBool = false;
            if (tmpAdmin == "yes")
                tmpBool = true;

            var newEmployee = new Employee(tmpId, tmpPassword, tmpName, tmpAdress, tmpBool);
            ListOfEmployees.Add(newEmployee);
        }

        public static void ShowEmployees()
        {
            Console.Clear();
            foreach(var item in ListOfEmployees)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Password);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Adress);
                Console.WriteLine(item.IsAdmin);
            }
        }
        public static void ReadFromFile()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.Combine(appDataFolder, "EmployeeList.csv");
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath));
            }
            if (new FileInfo(filePath).Length == 0)
            {
                using (var sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("Admin" + ";" + "1234" + ";" + "Admin Adminsson" + ";" + "Admingatan 123" + ";" + true);                 
                }
            }
            using (var reader = new StreamReader(filePath))
            {
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    bool tmpBool = false;
                    if (values[4].ToLower() == "true")
                        tmpBool = true;
                    ListOfEmployees.Add(new Employee(values[0], values[1], values[2], values[3], tmpBool));

                }
            }
        }
        public static void SaveListToFile()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.Combine(appDataFolder, "EmployeeList.csv");

            using (var sw = new StreamWriter(filePath))
            {
                foreach (var person in ListOfEmployees)
                {
                    sw.WriteLine(person.Id + ";" + person.Password + ";" + person.Name + ";" + person.Adress + ";" + person.IsAdmin);
                }
            }
            Console.WriteLine("Employeelist saved. Press any key to continue.");
            Console.ReadKey();
        }
        public static bool AdminLogIn(string Id, string Password)
        {
            bool logIn = false;
            foreach(var person in ListOfEmployees)
            {
                if (person.Id == Id && person.Password == Password && person.IsAdmin)
                    logIn = true;
            }
            return logIn;
        }

    }
}
