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
            var harryPotter = sCart.Items.Where(x => ((Book)x).Series == Book.SeriesEnum.HarryPotter);
            var differetBooks = harryPotter.Distinct().Select(x => x.Title);            
            
            var permutations = GetCombinations<Media>(harryPotter.ToList(), differetBooks.Count());

            List<IEnumerable<Media>> set = permutations.ToList();
            
            

            
            //if (differetBooks == 5) discount = (totPrice * 0.25);
            //else if (differetTitles == 4) discount = (totPrice * 0.20);
            //else if (differetTitles == 3) discount = (totPrice * 0.10);
            //else if (differetTitles == 2) discount = (totPrice * 0.05);

            
            return discount;
        }

        private double CalcSetDiscount(IList<IEnumerable<Media>> set)
        {
            double discount = 0;
            //set.ToList().ForEach(x => x.First())

            return discount;
        }

        /// <summary>
        /// Returns permutations
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetCombinations(list, length - 1)
                .SelectMany(t => list, (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        #endregion
    }
}
