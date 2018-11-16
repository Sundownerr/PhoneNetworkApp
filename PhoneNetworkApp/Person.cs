using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    // Класс абонента, состоит из полного имени,
    // номера телефона и адреса
    public class Person
    {
        private string fullName, phoneNumber, adress;
        private Rate rate;

        public string FullName { get => fullName; set => fullName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Adress { get => adress; set => adress = value; }
        public Rate Rate { get => rate; set => rate = value; }

        // Конструктор без параметров
        public Person()
        {
            fullName = "SampleName";          
            phoneNumber = "123456789";
            adress = "Sample adress";
            rate = new RateSimple();
        }

        // Конструктор с параметрами
        public Person(string fullName, string phoneNumber, string adress, Rate rate)
        {
            this.fullName = fullName;          
            this.phoneNumber = phoneNumber;
            this.adress = adress;
            this.rate = rate;
        }

        // Метод вывода информации об абоненте в консоль
        public void DisplayInfo()
        {
            Console.WriteLine($"{fullName}, {phoneNumber}, {adress}, {rate.DisplayInfo(false)}");
        }

        // Перегруженный метод вывода информации об абоненте в консоль
        public void DisplayInfo(bool showRate)
        {
            if(showRate)
                Console.WriteLine($"{fullName}, {phoneNumber}, {adress}, {rate.DisplayInfo(false)}");
            else
                Console.WriteLine($"{fullName}, {phoneNumber}, {adress}");
        }
    }
}
