using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    class RateSuper100 : Rate
    {
        public RateSuper100() : base()
        {
            name = $"Тариф 'Супер 100' без скидки";
            dailyCost = 5;
        }

        public RateSuper100(int dailyCost) : base(dailyCost)
        {
            name = $"Тариф 'Супер 100' со скидкой 50%";
            dailyCost -= (int)(dailyCost / 100 * 0.5);
        }

        public override int CalculateMonthlyCost()
        {
            base.CalculateMonthlyCost();
            return (int)(dailyCost / 100 * 0.5);
        }
    }
}
