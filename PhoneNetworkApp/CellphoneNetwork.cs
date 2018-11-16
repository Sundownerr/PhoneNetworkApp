using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    // Перечисление для метода поиска (для удобства)
    public enum SearchType
    {
        ByName,
        ByPhoneNumber
    }

    // Класс телефонной сети, состоит из списка абонентов
    public class CellphoneNetwork
    {
        private List<Person> personList;

        public List<Person> PersonList { get => personList; set => personList = value; }

        public CellphoneNetwork()
        {
            personList = new List<Person>();
        }
        
        // Метод поиска абонентов по критерию (имя или телефон)
        public void SearchBy(SearchType searchType, string parameter)
        {
            Console.WriteLine("\nРезультаты поиска: ");

            if (searchType == SearchType.ByName)
                for (int i = 0; i < personList.Count; i++)
                    if (personList[i].FullName.Contains(parameter))
                    {
                        personList[i].DisplayInfo();
                        return;
                    }

            if (searchType == SearchType.ByPhoneNumber)
                for (int i = 0; i < personList.Count; i++)
                    if (personList[i].PhoneNumber.Contains(parameter))
                    {
                        personList[i].DisplayInfo();
                        return;
                    }

            Console.WriteLine("Абоненты с такими параметрами не найдены.");
        }
    }
}
