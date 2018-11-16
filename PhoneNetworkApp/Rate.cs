using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
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

        public virtual int CalculateMonthlyCost()
        {
            return dailyCost * 30;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Name}, {CalculateMonthlyCost()}р. в месяц");
        }
    }
}
