using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    // Родительский класс тарифов, состоит из названия и 
    // стоимости за день
    public abstract class Rate
    {
        protected int dailyCost;
        protected string name;

        public int DailyCost { get => dailyCost; set => dailyCost = value; }
        public string Name { get => name; set => name = value; }

        public Rate()
        {
            dailyCost = 10;
        }

        public Rate(int dailyCost)
        {
            this.dailyCost = dailyCost;
        }

        // Метод подсчета стоимости за месяц
        public virtual int CalculateMonthlyCost()
        {
            return dailyCost * 30;
        }

        // Метод вывода информации в консоль
        public void DisplayInfo()
        {
            Console.WriteLine($"{Name}, {dailyCost}р. в день, {CalculateMonthlyCost()}р. в месяц");
        }

        // Перегруженный метод вывода, который возвращает строку
        // вместо вывода в консоль
        public string DisplayInfo(bool showFull)
        {
            if(showFull)
                return $"{Name}, {CalculateMonthlyCost()}р. в месяц";
            else
                return $"{Name}";
        }
    }
}
