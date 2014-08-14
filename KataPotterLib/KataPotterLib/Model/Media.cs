using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPotterLib.Model
{
  /// <summary>
  /// Base class
  /// </summary>
  public class Media : IMedia
  {
    #region Properties
    public Guid Id { get; set; }
    public double Price { get; set; }
    public string Title { get; set; }
    #endregion

    #region Methods
    public override bool Equals(object obj)
    {
      var item = (Media)obj;
      if (item == null)
        return false;

      return this.Title.Equals(item.Title);
    }
    public override int GetHashCode()
    {
      return this.Title.GetHashCode();
    }
    public virtual object Clone()
    {
      var clonedObj = new Media();
      clonedObj.Id = this.Id;
      clonedObj.Price = this.Price;
      clonedObj.Title = this.Title;      

      return clonedObj;
    }

    #endregion
  }
}
