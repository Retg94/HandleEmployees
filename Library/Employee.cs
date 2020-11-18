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

        public string Id { get; }
        public string Password { get; }
        public string Name { get; }
        public string Adress { get; }
        public bool IsAdmin { get; }
    }
}
