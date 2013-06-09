using KataPotterLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPotterLib.Utils
{
    public class Utils
    {
        //Harry Potter Titles
        private const string FIRST_BOOK = "Harry Potter and the Sorcerer's Stone";
        private const string SECOND_BOOK = "Harry Potter and the Chamber of Secrets";
        private const string THIRD_BOOK = "Harry Potter and the Prisoner of Azkaban";
        private const string FOURTH_BOOK = "Harry Potter and the Goblet of Fire";
        private const string FIFTH_BOOK = "Harry Potter and the Order of the Phoenix";

        private const string AUTHOR = "J.K. Rowling";
        //Help methods
        public static Media GetFirstBook()
        {
            return new Book(
                8, FIRST_BOOK, "11", AUTHOR, Book.SeriesEnum.HarryPotter);
        }
        public static Media GetSecondBook()
        {
            return new Book(
                8, SECOND_BOOK, "22", AUTHOR, Book.SeriesEnum.HarryPotter);
        }
        public static Media GetThirdBook()
        {
            return new Book(
                8, THIRD_BOOK, "33", AUTHOR, Book.SeriesEnum.HarryPotter);
        }
        public static Media GetFourthBook()
        {
            return new Book(
                8, FOURTH_BOOK, "44", AUTHOR, Book.SeriesEnum.HarryPotter);
        }
        public static Media GetFifthBook()
        {
            return new Book(
                8, FOURTH_BOOK, "55", AUTHOR, Book.SeriesEnum.HarryPotter);
        }

    }
}
