using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class PotterCalculator
    {
        public double Calculator(HarryPotter buyList)
        {
            double amount = 0;

            HarryPotter copy = new HarryPotter();


            amount = Count(buyList);

            return amount;
        }

        private double Count(HarryPotter buyList)
        {
            double amount = 0;

            List<DiscountBuy> discount = buyList.GetType().GetProperties()
                .Where(prop => prop.GetValue(buyList) is int)
                .Select(val => val)
                .Where(val => (int)val.GetValue(buyList) > 0)
                .Select(val => new DiscountBuy {
                    BookVol = val.Name,
                    BookCount = double.Parse(val.GetValue(buyList).ToString()) })
                .ToList();
           
            if (discount.Count() == 1)
                amount = discount.First().BookCount * buyList.BookPrice;

            return amount;
        }
    }
}
