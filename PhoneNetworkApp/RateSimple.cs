using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    public class RateSimple : Rate
    {
        public float discount;

        public RateSimple() : base()
        {
            dailyCost -= (int)(dailyCost / 100 * discount);
        }

        public RateSimple(int dailyCost) : base(dailyCost)
        {
            dailyCost -= (int)(dailyCost / 100 * discount);
        }

        
    }
}
