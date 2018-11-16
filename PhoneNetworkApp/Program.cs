using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    class Program
    {
        private delegate void DelegateAction();

        static void Main(string[] args)
        {         
            var network = new CellphoneNetwork();          
            var action = new DelegateAction(Exit);
            var random = new Random();
            action = null;
            var rateList = new Rate[2]
            {
                new RateSimple(),
                new RateSuper100()
            };

            var file = File.ReadAllLines("spisok.txt", Encoding.Default);
            
            for (int i = 0; i < file.Length; i++)
            {
                var personData = file[i].Split(new char[] { ',' });             
                network.PersonList.Add(new Person(personData[0], personData[1], personData[2], rateList[random.Next(0, 2)]));
            }

            Console.WriteLine("Программа ведения учета абонентов телефонной сети\n\n");
            Console.WriteLine("Введите номер нужной опции что бы продолжить: \n\n" +
                " 1. Вывести информацию о всех абонентах \n" +
                " 2. Найти абонента по имени \n" +
                " 3. Найти абонента по номеру телефона \n" +
                " 4. Выход \n ");

            var input = Console.ReadLine();
            var result = 0;

            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("\nВведите номер нужной опции что бы продолжить: \n");
                input = Console.ReadLine();           
            }

            action = result == 1 ? ShowPersonList :
                     result == 2 ? SearchByName :
                     result == 3 ? SearchByPhoneNumber :
                     result == 4 ? Exit : null as DelegateAction;
            action?.Invoke();
            action = null;
          

            void Exit()
            {
                Environment.Exit(0);
            }

            void ShowPersonList()
            {
                for (int i = 0; i < network.PersonList.Count; i++)
                    network.PersonList[i].DisplayInfo();         
            }

            void SearchByName()
            {
                network.SearchBy(SearchType.ByName);
            }

            void SearchByPhoneNumber()
            {
                network.SearchBy(SearchType.ByPhoneNumber);
            }
        }
    }
}
