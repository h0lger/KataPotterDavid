using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPotterLib.Model
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            //Initialize
            this.Items = new List<Media>();
        }
        #region Properties
        public IList<Media> Items { private set; get; }
        #endregion
    }
}
