using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Library
{
    public class HandleList
    {
        public static List<Employee> ListOfEmployees = new List<Employee>();

        private static string VerifyId(string tmpId)
        {
            bool idControll = false;
            foreach (var person in ListOfEmployees)
            {
                if (tmpId == person.Id)
                    idControll = true;
            }
            while (idControll || !Verify.VerifyStringNoSpaces(tmpId))
            {
                Console.WriteLine("Invalid ID, please write an uniqe ID. You can only use letters and numbers. The length must be between 5-20 characters.");
                Console.WriteLine("Write new ID: ");
                tmpId = Console.ReadLine();
                idControll = false;
                foreach (var person in ListOfEmployees)
                {
                    if (tmpId == person.Id)
                        idControll = true;
                }
            }
            return tmpId;
        }
        private static string VerifyPassword(string tmpPassword)
        {
            while (!Verify.VerifyStringNoSpaces(tmpPassword))
            {
                Console.WriteLine("Invalid password. You can only use letters and numbers. The length must be between 5-20 characters. ");
                Console.WriteLine("Write new password: ");
                tmpPassword = Console.ReadLine();
            }
            return tmpPassword;
        }
        private static string VerifyName(string tmpName)
        {
            while (!Verify.VerifyStringWithSpaces(tmpName))
            {
                Console.WriteLine("Invalid name. You can only use letters, numbers and spaces. The length must be between 5-20 characters. Try again. ");
                Console.WriteLine("Write new name: ");
                tmpName = Console.ReadLine().Trim();
            }
            return tmpName;
        }
        private static string VerifyAdress(string tmpAdress)
        {
            while(!Verify.VerifyStringWithSpaces(tmpAdress))
            {
                Console.WriteLine("Invalid adress. You can only use letters, numbers and spaces. The length must be between 5-20 characters. Try again. ");
                Console.WriteLine("Write new adress: ");
                tmpAdress = Console.ReadLine().Trim();
            }
            return tmpAdress;
        }
        public static void AddNewEmployee()
        {
            Console.Clear();
            Console.WriteLine("-- ADDING NEW EMPLOYEE --");

            Console.WriteLine("Write new ID: ");
            string tmpId = Console.ReadLine();
            tmpId = VerifyId(tmpId);
            
            Console.WriteLine("Write new password: ");
            string tmpPassword = Console.ReadLine();
            tmpPassword = VerifyPassword(tmpPassword);

            Console.WriteLine("Write name of employee: ");
            string tmpName = Console.ReadLine();
            tmpName = VerifyName(tmpName);

            Console.WriteLine("Write adress of employee: ");
            string tmpAdress = Console.ReadLine();
            tmpAdress = VerifyAdress(tmpAdress);

            Console.WriteLine("Is this employee an Admin? Yes/No");
            string tmpAdmin = Console.ReadLine().ToLower();
            bool tmpBool = false;
            if (tmpAdmin == "yes")
                tmpBool = true;

            var newEmployee = new Employee(tmpId, tmpPassword, tmpName, tmpAdress, tmpBool);
            ListOfEmployees.Add(newEmployee);
        }
        private static void WriteList()
        {
            int tmp = 0;
            foreach (var person in ListOfEmployees)
            {
                Console.WriteLine($"[{tmp}] ID:{person.Id}, Name:{person.Name}");
                tmp++;
            }
            Console.WriteLine("-----------------------------------------------------------");
        }
        private static string EditInfoSwitchCase(string userInput, Employee item, bool isAdmin, string tmpId)
        {
            switch (userInput)
            {
                case "id":
                    Console.WriteLine("Write new ID:");
                    tmpId = Console.ReadLine();
                    tmpId = VerifyId(tmpId);
                    item.Id = tmpId;
                    Console.WriteLine($"ID updated to {item.Id}");
                    break;

                case "password":
                    Console.WriteLine("Write new password: ");
                    string tmpPassword = Console.ReadLine();
                    tmpPassword = VerifyPassword(tmpPassword);
                    item.Password = tmpPassword;
                    Console.WriteLine($"Password updated to {item.Password}");
                    break;

                case "name":
                    Console.WriteLine("Write new name: ");
                    string tmpName = Console.ReadLine();
                    tmpName = VerifyName(tmpName);
                    item.Name = tmpName;
                    Console.WriteLine($"Name updated to {item.Name}");
                    break;
                case "adress":
                    Console.WriteLine("Write new adress: ");
                    string tmpAdress = Console.ReadLine();
                    tmpAdress = VerifyAdress(tmpAdress);
                    item.Adress = tmpAdress;
                    Console.WriteLine($"Adress updated to {item.Adress}");
                    break;
                case "adminstatus":
                    if(isAdmin == false)
                    {
                        Console.WriteLine("You can't edit adminstatus in this application. You must be an admin logged into the adminapplication. Returning to mainmenu..");
                        break;
                    }
                    Console.WriteLine("Are you sure that you want do change Adminstatus? (Y/N)");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        if (item.IsAdmin == true)
                            item.IsAdmin = false;
                        else
                            item.IsAdmin = true;
                        Console.WriteLine($"Adminstatus changed to {item.IsAdmin}");
                        PressAnyKeyToContinue();
                    }
                    break;
                default:
                    Console.WriteLine("Error, returning to mainmenu..");
                    break;

            }
            return tmpId;
        }
        public static string EditEmployee(bool isAdmin, string tmpId)
        {
            Console.WriteLine("-- Edit an employee --");
            WriteList();
            Console.WriteLine("Write the number infront of the employee you want to edit: ");
            int choice = Verify.StringToInt(Console.ReadLine());
            int index = 0;
            if (choice >= 0 && choice < ListOfEmployees.Count)
            {
                foreach(var item in ListOfEmployees)
                {
                    if(index == choice)
                    {
                        WriteEmployeeInfo(item);
                        Console.WriteLine("What do you want to edit? Id/Password/Name/Adress/Adminstatus");
                        string userInput = Console.ReadLine().ToLower();
                        EditInfoSwitchCase(userInput, item, isAdmin, tmpId);
                    }
                    index++;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, returning to menu.");
                PressAnyKeyToContinue();
            }
            return tmpId;
        }
        public static void RemoveEmploye()
        {
            Console.Clear();
            Console.WriteLine("-- Removing an employee --");
            WriteList();
            Console.WriteLine("Write the number infront of the employee you want to remove or x to go back to menu: ");
            string userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            if (userInput == "x")
                return;
            int userInputToInt;
            bool check = int.TryParse(userInput, out userInputToInt);
            while(!check && userInput!="x")
            {
                Console.WriteLine("Invalid input. Write the number infront of the employee you want to remove or x to go back to menu: ");
                userInput = Console.ReadLine();
                userInput = userInput.ToLower();
                if (userInput == "x")
                    return;
                check = int.TryParse(userInput, out userInputToInt);
            }
           
            
            if(userInputToInt>=0 && userInputToInt<ListOfEmployees.Count)
            {
                ListOfEmployees.RemoveAt(userInputToInt);
                Console.WriteLine("Employee removed. Press any key to return to menu.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input, press any key to return to menu..");
                Console.ReadKey();
            }
            

        }
        private static void WriteEmployeeInfo(Employee item)
        {
            Console.WriteLine($"Id: {item.Id}");
            Console.WriteLine($"Password: {item.Password}");
            Console.WriteLine($"Name: {item.Name}");
            Console.WriteLine($"Adress: {item.Adress}");
            Console.WriteLine($"Adminstatus: {item.IsAdmin}");
            Console.WriteLine();
        }
        public static void ShowEmployeesForAdmin()
        {
            Console.Clear();
            foreach(var item in ListOfEmployees)
            {
                WriteEmployeeInfo(item);
            }
            PressAnyKeyToContinue();
        }
        public static void ShowEmployeesForEmployee()
        {
            Console.Clear();
            foreach (var item in ListOfEmployees)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Adress: {item.Adress}");
                Console.WriteLine($"Adminstatus: {item.IsAdmin}");
                Console.WriteLine();
            }
            PressAnyKeyToContinue();
        }

        public static void ShowOwnInfo(string id)
        {
            Console.Clear();
            foreach (var item in ListOfEmployees)
            {
                if(item.Id==id)
                {
                    Console.WriteLine($"Id: {item.Id}");
                    Console.WriteLine($"Password: {item.Password}");
                    Console.WriteLine($"Name: {item.Name}");
                    Console.WriteLine($"Adress: {item.Adress}");
                    Console.WriteLine($"Adminstatus: {item.IsAdmin}");
                    Console.WriteLine();
                }
            }
            PressAnyKeyToContinue();
        }
        public static int GetIndexOfId(string id)
        {
            int index = 0;
            foreach(var item in ListOfEmployees)
            {
                if (item.Id == id)
                    break;
                index++;
            }
            return index;
        }
        public static string EditOwnInfo(string id, bool isAdmin)
        {
            string tmpId = id;
            Console.Clear();
            Console.WriteLine("-- Edit own information menu --");
            Console.WriteLine("This is your current information: ");
            ShowOwnInfo(id);
            Console.WriteLine();
            Console.WriteLine("What do you want to edit? Id/Password/Name/Adress");
            foreach(var item in ListOfEmployees)
            {
                if(item.Id==id)
                {
                    string userInput = Console.ReadLine().ToLower();
                    tmpId = EditInfoSwitchCase(userInput, item, isAdmin, tmpId);
                }
            }
            PressAnyKeyToContinue();
            return tmpId;
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
                    if(values[4].ToLower() == "true")
                        tmpBool = true;
                    ListOfEmployees.Add(new Employee(values[0], values[1], values[2], values[3], tmpBool));

                }
            }
        }
        public static void SaveListToFile()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.Combine(appDataFolder, "EmployeeList.csv");
            FileStream fsOverwrite = new FileStream(filePath, FileMode.Create);
            using (StreamWriter swOverwrite = new StreamWriter(fsOverwrite))
            {
                foreach (var person in ListOfEmployees)
                {
                    swOverwrite.WriteLine(person.Id + ";" + person.Password + ";" + person.Name + ";" + person.Adress + ";" + person.IsAdmin);
                }
            }
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

        public static bool EmployeeLogIn(string Id, string Password)
        {
            bool logIn = false;
            foreach (var person in ListOfEmployees)
            {
                if (person.Id == Id && person.Password == Password)
                    logIn = true;
            }
            return logIn;
        }
        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
    }
}
