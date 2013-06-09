using System;
using System.Collections.Generic;
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
            int differetTitles = harryPotter.Distinct().Count();

            
            if (differetTitles == 5) discount = (totPrice * 0.25);
            else if (differetTitles == 4) discount = (totPrice * 0.20);
            else if (differetTitles == 3) discount = (totPrice * 0.10);
            else if (differetTitles == 2) discount = (totPrice * 0.05);

            
            return discount;
        }
        #endregion
    }
}
