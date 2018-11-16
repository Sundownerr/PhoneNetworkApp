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

            // Список со случайными тарифами
            var rateList = new Rate[4]
            {
                new RateSimple(),
                new RateSuper100(),
                new RateSimple(20, 20),
                new RateSuper100(30)
            };

            // Считывание информации из файла
            var file = File.ReadAllLines("spisok.txt", Encoding.Default);
            
            // Разделение считанной информации на имя, телефон, адрес
            for (int i = 0; i < file.Length; i++)
            {
                var personData = file[i].Split(new char[] { ',' });             
                network.PersonList.Add(new Person(personData[0], personData[1], personData[2], rateList[random.Next(0, 4)]));
            }

            Console.WriteLine("Программа ведения учета абонентов телефонной сети\n\n");

            ShowMenu();
            var input = Console.ReadLine();
           
            CheckInput();     
          
            // Локальный метод для получения ввода пользователя программы
            void CheckInput()
            {              
                while (!int.TryParse(input, out result) || result < 1 || result > 5)
                {
                    ShowMenu();
                    input = Console.ReadLine();
                }
                input = string.Empty;

                // Выбор метода для делегата, основываясь на вводимой информации
                action = 
                    result == 1 ? ShowPersonList :
                    result == 2 ? ShowRateList :
                    result == 3 ? SearchByName :
                    result == 4 ? SearchByPhoneNumber :
                    result == 5 ? Exit : null as DelegateAction;
                action?.Invoke();
                action = null;            
            }

            // Локальный метод для выхода из программы
            void Exit()
            {
                Environment.Exit(0);
            }

            // Локальный метод для отображения всех абонентов
            void ShowPersonList()
            {
                for (int i = 0; i < network.PersonList.Count; i++)
                    network.PersonList[i].DisplayInfo();             
                CheckInput();
            }

            // Локальный метод для отображения всех тарифов
            void ShowRateList()
            {
                for (int i = 0; i < rateList.Length; i++)
                    rateList[i].DisplayInfo();
                CheckInput();
            }

            // Локальный метод для поиска абонентов по имени
            void SearchByName()
            {
                Console.WriteLine("Введите часть имени или полное имя: ");
                network.SearchBy(SearchType.ByName, Console.ReadLine());
                CheckInput();
            }

            // Локальный метод для поиска абонентов по номеру телефона
            void SearchByPhoneNumber()
            {           
                Console.WriteLine("Введите часть номера или полный номер: ");
                network.SearchBy(SearchType.ByPhoneNumber, Console.ReadLine());
                CheckInput();
            }

            // Локальный метод для отображения меню
            void ShowMenu()
            {         
                Console.WriteLine("\nВведите номер нужной опции что бы продолжить: \n\n" +
                    " 1. Вывести информацию о всех абонентах \n" +
                    " 2. Вывести информацию о всех тарифах \n" +
                    " 3. Найти абонента по имени \n" +
                    " 4. Найти абонента по номеру телефона \n" +
                    " 5. Выход \n ");
            }
        }
    }
}
