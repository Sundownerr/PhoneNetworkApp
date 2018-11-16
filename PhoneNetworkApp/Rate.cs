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

        public int DailyCost { get => dailyCost; set => dailyCost = value; }

        public Rate()
        {
            dailyCost = new Random().Next(1, 10);
        }

        public Rate(int dailyCost)
        {
            this.dailyCost = dailyCost;
        }

        public virtual int CalculateMonthlyCost()
        {
            return DailyCost * 30;
        }
    }
}
