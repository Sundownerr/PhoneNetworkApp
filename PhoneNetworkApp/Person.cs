using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    public class Person
    {
        private string fullName, phoneNumber, adress;
        private Rate rate;

        public string FullName { get => fullName; set => fullName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Adress { get => adress; set => adress = value; }
        public Rate Rate { get => rate; set => rate = value; }

        public Person()
        {
            fullName = "SampleName";          
            phoneNumber = "123456789";
            adress = "Sample adress";
            rate = new RateSimple();
        }

        public Person(string fullName, string phoneNumber, string adress, Rate rate)
        {
            this.fullName = fullName;          
            this.phoneNumber = phoneNumber;
            this.adress = adress;
            this.rate = rate;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{fullName}, {phoneNumber}, {adress}, {rate.DisplayInfo(false)}");
        }
        
        public void DisplayInfo(bool showRate)
        {
            if(showRate)
                Console.WriteLine($"{fullName}, {phoneNumber}, {adress}, {rate.DisplayInfo(false)}");
            else
                Console.WriteLine($"{fullName}, {phoneNumber}, {adress}");
        }
    }
}
