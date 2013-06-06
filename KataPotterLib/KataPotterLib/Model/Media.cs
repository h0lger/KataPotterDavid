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
    public class Media: IMedia
    {
        #region Properties
        public double Price { get; set; }
        public string Title { get; set; }
        #endregion
    }
}
