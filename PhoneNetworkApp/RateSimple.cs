using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    public class RateSimple : Rate
    {
        private float discount;

        public float Discount { get => discount; set => discount = value; }

        public RateSimple() : base()
        {
            name = $"Тариф 'Простой' без скидки";
            dailyCost = 3;
        }

        public RateSimple(int dailyCost, int discount) : base(dailyCost)
        {
            name = $"Тариф 'Простой' со скидкой {discount}%";
            dailyCost -= (dailyCost / 100 * discount);
        }

        public override int CalculateMonthlyCost()
        {
            base.CalculateMonthlyCost();
            return (int)(dailyCost / 100 * discount);
        }
    }
}
