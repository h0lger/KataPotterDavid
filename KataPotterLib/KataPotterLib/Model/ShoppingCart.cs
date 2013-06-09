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
        #region Methods
        public void AddToShoppingCart(Media item, int copies)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            if (copies <= 0)
                throw new ArgumentOutOfRangeException("copeis");

            for (int i = 0; i < copies; i++)
            {
                this.Items.Add(item);
            }
        }
        /// <summary>
        /// Number of items in shopping cart
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return this.Items.Count;
        }
        #endregion
        #region Properties
        public IList<Media> Items { private set; get; }
        #endregion
    }
}
