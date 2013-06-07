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
        public static double CalcTotalPrice(ShoppingCart sCart)
        {
            double totPrice = 0;

            sCart.Items.ToList().ForEach(x => totPrice += x.Price);

            return totPrice;
        }

        public static double CalcDiscount()
        {
            double discount = 0;

            return discount;
        }
        #endregion
    }
}
