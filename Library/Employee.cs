using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Employee
    {
        public Employee(string id, string password, string name, string adress, bool isAdmin)
        {
            Id = id;
            Password = password;
            Name = name;
            Adress = adress;
            IsAdmin = isAdmin;
        }

        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public bool IsAdmin { get; set; }
    }
}
