using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPotterLib.Model
{
    public class Book: Media
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="price"></param>
        /// <param name="title"></param>
        /// <param name="isbn"></param>
        /// <param name="author"></param>
        public Book(double price, string title, string isbn, string author)
        {
            this.Price = price;
            this.Title = title;
            this.Isbn = isbn;
            this.Author = author;
        }
        #endregion
        
        #region Properties
        public string Isbn { get; set; }
        public string Author { get; set; }
        public SeriesEnum Series { get; set; } 
        #endregion

        #region Enums
        public enum SeriesEnum
        {
            NA = 0,
            First = 1,
            Second = 2, 
            Third = 3, 
            Fourth = 4,
            Fifth = 5
        }
        #endregion

    }
}
