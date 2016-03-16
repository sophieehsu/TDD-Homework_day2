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

            Count(buyList, ref amount);

            return amount;
        }

        private void Count(HarryPotter buyList, ref double Amount)
        {            
            List<DiscountBuy> discountList = buyList.GetType().GetProperties()
                .Where(prop => prop.GetValue(buyList) is int)
                .Select(val => val)
                .Where(val => (int)val.GetValue(buyList) > 0)
                .Select(val => new DiscountBuy {
                    BookVol = val.Name,
                    BookCount = double.Parse(val.GetValue(buyList).ToString()) })
                .ToList();           

            double bookCount = discountList.Count, discount = 1;

            switch (discountList.Count)
            {
                case 5:
                    discount = 0.75;
                    break;
                case 4:
                    discount = 0.8;
                    break;
                case 3:
                    discount = 0.9;
                    break;
                case 2:
                    discount= 0.95;
                    break;
                case 1:
                    bookCount = discountList.First().BookCount;
                    break;
                default:
                    discount = 0;
                    break;
            }

            Amount += bookCount * buyList.BookPrice * discount;

            if (discountList.Count > 1)
            {
                foreach (var i in discountList)
                {
                    PropertyInfo pinfo = typeof(HarryPotter).GetProperty(i.BookVol);
                    int intCount = (int)pinfo.GetValue(buyList);
                    pinfo.SetValue(buyList, intCount - 1);
                }

                Count(buyList, ref Amount);
            }
        }
    }
}