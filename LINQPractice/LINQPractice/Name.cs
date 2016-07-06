using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    public class Name
    {
        public readonly string FirtsName;
        public readonly string LastName;
        public readonly string Patronymic;

        public Name(string firstName, string lastName)
        {
            FirtsName = firstName;
            LastName = lastName;
        }
        public Name(string firstName, string lastName, string patronymic)
        {
            FirtsName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
        }

        public override string ToString()
        {
            return $"{FirtsName} {LastName}";
        }

        public string FullName()
        {
            return $"{FirtsName} {LastName} {Patronymic}";
        }
    }
}
