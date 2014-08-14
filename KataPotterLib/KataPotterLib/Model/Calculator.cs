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
      //Calc Harry Potter series discount
      Dictionary<IList<int>, double> combinations = new Dictionary<IList<int>, double>();

      //Search for all combination between 2-5 (the one's you got discount for)
      for (int i = 5; i >= 2; i--)
      {
        double discount = 0;
        var uniqueTitles = sCart.Items.Select(x => x.Title).Distinct();
        HashSet<Guid> handled = new HashSet<Guid>(); //To know calculated
        IList<int> uniqueSets = new List<int>();

        while (sCart.Items.Any(x => !handled.Contains(x.Id)))
        {
          HashSet<string> tmpTitles = new HashSet<string>();
          var uniques = sCart.Items.Where(x => !handled.Contains(x.Id));
          foreach (var sItem in uniques)
          {
            if (tmpTitles.Count <= i && !tmpTitles.Contains(sItem.Title))
            {
              tmpTitles.Add(sItem.Title);
              handled.Add(sItem.Id);
            }
          }

          uniqueSets.Add(tmpTitles.Count);
        }

        //Calculate discount for each set
        foreach (int uni in uniqueSets)
        {
          double price = sCart.Items.First().Price;
          discount += CalcSetDiscount(uni, price);
        }

        //Save the total discount for this combination
        combinations.Add(uniqueSets, discount);
      }     

      //Pick the comination with highest possible discount
      return combinations.Max(x => x.Value);
    }

    private static double CalcSetDiscount(int uniqueTitles, double price)
    {
      switch (uniqueTitles)
      {
        //case 5:
        //  return nBooks * price * 0.75; //25%
        case 4:
          return price * 0.20 * uniqueTitles; //20%
        case 3:
          return price * 0.10 * uniqueTitles; //10%
        case 2:
          return price * 0.05 * uniqueTitles; //5%
        case 1:
          return 0;
        case 0:
          return 0;

        // >=5 books
        default:
          return price * 0.25 * uniqueTitles; //25%
      }
    }

  }
}

    #endregion