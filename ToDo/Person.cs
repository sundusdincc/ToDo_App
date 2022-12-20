using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Interfaces;

namespace ToDo
{
    public class Person : IPerson
    {
        private string name;
        private string surname;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }

        public Person()
        {

        }
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}