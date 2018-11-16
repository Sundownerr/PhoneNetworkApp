using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    public class Person
    {
        public Person()
        {
            name = "SampleName";
            surname = "SampleSurname";
            phoneNumber = "123456789";
        }

        private string name, surname, phoneNumber;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
