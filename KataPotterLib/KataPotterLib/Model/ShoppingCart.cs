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
        //First copy doesn't need to be cloned
        if (i == 0)
          this.Items.Add(item);
        else
        {
          var cloned = item.Clone();
          ((Media)cloned).Id = Guid.NewGuid();
          this.Items.Add(cloned as Media);
        }
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
