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
            adress = "Sample adress";
            rate = new RateSimple();
        }

        private string name, surname, phoneNumber, adress;
        private Rate rate;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Adress { get => adress; set => adress = value; }
        public Rate Rate { get => rate; set => rate = value; }
    }
}
