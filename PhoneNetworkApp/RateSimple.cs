using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    // Дочерний класс тарифа - тариф "Простой",
    // дополнительно содержит в себе значение скидки
    public class RateSimple : Rate
    {
        private float discount;

        public float Discount { get => discount; set => discount = value; }

        public RateSimple() 
        {           
            dailyCost = 20;
            discount = 0;
            name = $"Тариф 'Простой' без скидки";
        }

        // Наследование конструктора
        public RateSimple(int dailyCost, float discount) : base(dailyCost)
        {
            this.discount = discount;
            this.dailyCost -= (int)(dailyCost / 100 * (discount));
            name = $"Тариф 'Простой' со скидкой {discount}%";        
        }

        // Переопределенный метод подсчета стоимости за месяц
        public override int CalculateMonthlyCost()
        {
            base.CalculateMonthlyCost();
            return discount > 0 ? (int)(dailyCost * 30 - dailyCost * 30 / 100 * (discount)) : dailyCost * 30;
        }
    }
}
