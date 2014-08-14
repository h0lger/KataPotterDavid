using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPotterLib.Model
{
    interface IMedia: ICloneable
    {     
        double Price {get; set;}
        string Title {get; set; }     
    }
}
