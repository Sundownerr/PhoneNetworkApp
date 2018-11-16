using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    class RateSuper100 : Rate
    {
        private float discount;

        public float Discount { get => discount; set => discount = value; }

        public RateSuper100() 
        {
            dailyCost = 30;
            discount = 0;
            name = $"Тариф 'Супер 100' без скидки";
        }

        public RateSuper100(int dailyCost) : base(dailyCost)
        {
            discount = 50;           
            this.dailyCost -= (int)(dailyCost / 100 * discount);
            name = $"Тариф 'Супер 100' со скидкой 50%";
        }

        public override int CalculateMonthlyCost()
        {
            base.CalculateMonthlyCost();
            return discount > 0 ? (int)(dailyCost * 30 - dailyCost * 30 / 100 * (discount)) : dailyCost * 30;
        }
    }
}
