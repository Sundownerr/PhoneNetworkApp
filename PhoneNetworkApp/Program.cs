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
            var result = 0;
            action = null;
            var rateList = new Rate[4]
            {
                new RateSimple(),
                new RateSuper100(),
                new RateSimple(2, 10),
                new RateSuper100(51)
            };

            var file = File.ReadAllLines("spisok.txt", Encoding.Default);
            
            for (int i = 0; i < file.Length; i++)
            {
                var personData = file[i].Split(new char[] { ',' });             
                network.PersonList.Add(new Person(personData[0], personData[1], personData[2], rateList[random.Next(0, 4)]));
            }

            Console.WriteLine("Программа ведения учета абонентов телефонной сети\n\n");

            ShowMenu();
            var input = Console.ReadLine();
           
            CheckInput();     
          
            void CheckInput()
            {              
                while (!int.TryParse(input, out result) || result < 1 || result > 4)
                {
                    ShowMenu();
                    input = Console.ReadLine();
                }
                input = string.Empty;

                action = 
                    result == 1 ? ShowPersonList :
                    result == 2 ? SearchByName :
                    result == 3 ? SearchByPhoneNumber :
                    result == 4 ? Exit : null as DelegateAction;
                action?.Invoke();
                action = null;            
            }
            
            void Exit()
            {
                Environment.Exit(0);
            }

            void ShowPersonList()
            {
                for (int i = 0; i < network.PersonList.Count; i++)
                    network.PersonList[i].DisplayInfo();             
                CheckInput();
            }

            void SearchByName()
            {
                Console.WriteLine("Введите часть имени или полное имя: ");
                network.SearchBy(SearchType.ByName, Console.ReadLine());

                CheckInput();
            }

            void SearchByPhoneNumber()
            {           
                Console.WriteLine("Введите часть номера или полный номер: ");
                network.SearchBy(SearchType.ByPhoneNumber, Console.ReadLine());

                CheckInput();
            }

            void ShowMenu()
            {         
                Console.WriteLine("\nВведите номер нужной опции что бы продолжить: \n\n" +
                    " 1. Вывести информацию о всех абонентах \n" +
                    " 2. Найти абонента по имени \n" +
                    " 3. Найти абонента по номеру телефона \n" +
                    " 4. Выход \n ");
            }
        }
    }
}
