using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPotterLib.Model
{
    public class Calculator
    {
        #region Methods
        /// <summary>
        /// Calculates total price incl discount
        /// </summary>
        /// <param name="sCart"></param>
        /// <returns></returns>
        public static double CalcTotalPrice(ShoppingCart sCart)
        {
            double totPrice = 0;

            sCart.Items.ToList().ForEach(x => totPrice += x.Price);

            return (totPrice - CalcDiscount(sCart, totPrice));
        }

        public static double CalcDiscount(ShoppingCart sCart, double totPrice)
        {
            double discount = 0;

            //Calc Harry Potter series discount
            List<string> harryPotter = sCart.Items.Where(x =>
                ((Book)x).Series == Book.SeriesEnum.HarryPotter).Select(x => x.Title).ToList();

            var allCombos = CalcCombinations(harryPotter).ToList();

            
            

            return discount;
        }

        private double CalcSetDiscount(int nDifferentTitles, int nBooks, double price)
        {
            switch (nDifferentTitles)
            {
                case 5:
                    return nBooks * price * 0.75;
                case 4:
                    return nBooks * price * 0.80;
                case 3:
                    return nBooks * price * 0.90;
                case 2:
                    return nBooks * price * 0.95;
                case 1:
                    return nBooks * price * 1;

                default:
                    throw new InvalidOperationException();
            }
        }


        private static IEnumerable<int> ConstructSetFromBits(int i)
        {
            for (int n = 0; i != 0; i /= 2, n++)
            {
                if ((i & 1) != 0)
                    yield return n;
            }
        }


        private static IEnumerable<List<string>> ProduceEnumeration(List<string> allValues)
        {
            for (int i = 0; i < (1 << allValues.Count); i++)
            {
                yield return
                    ConstructSetFromBits(i).Select(n => allValues[n]).ToList();
            }
        }

        public static List<List<string>> CalcCombinations(List<string> allValues)
        {
            return ProduceEnumeration(allValues).ToList();
        }
    }
}
      
#endregion