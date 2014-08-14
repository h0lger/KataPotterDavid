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
      
      for (int i = 5; i > 0; i--)
      {
        double discount = 0;
        var uniqueTitles = sCart.Items.Select(x => x.Title).Distinct();
        HashSet<Guid> handled = new HashSet<Guid>();
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


        foreach (int uni in uniqueSets)
        {
          double price = sCart.Items.First().Price;
          discount += CalcSetDiscount(uni, price);
        }

        combinations.Add(uniqueSets, discount);

      }

      //var allCombos = CalcCombinations(sCart.Items.ToList());

      //allCombos.ForEach(x =>
      //  {

      //  });

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


    private static IEnumerable<int> ConstructSetFromBits(int i)
    {
      for (int n = 0; i != 0; i /= 2, n++)
      {
        if ((i & 1) != 0)
          yield return n;
      }
    }


    private static IEnumerable<List<Media>> ProduceEnumeration(List<Media> allValues)
    {
      for (int i = 0; i < (1 << allValues.Count); i++)
      {
        yield return
            ConstructSetFromBits(i).Select(n => allValues[n]).ToList();
      }
    }

    public static List<List<Media>> CalcCombinations(List<Media> allValues)
    {
      return ProduceEnumeration(allValues).ToList();
    }

  }
}

    #endregion