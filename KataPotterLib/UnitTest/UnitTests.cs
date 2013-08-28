using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataPotterLib.Model;
using KataPotterLib.Utils;


namespace UnitTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void AddRemoveBooks()
        {
            ShoppingCart SCart = new ShoppingCart();
            //Creation of 100 books
            for (int i = 0; i < 100; i++)
            {
                Book tmpBook = new Book(
                    (100 * i), "TestBook", Guid.NewGuid().ToString(), "Harry", Book.SeriesEnum.HarryPotter);
                SCart.Items.Add(tmpBook);
            }
            Assert.AreEqual<int>(100, SCart.Count());

            //Add 20 copies
            SCart.AddToShoppingCart(Utils.GetSecondBook(), 20);
            Assert.AreEqual<int>(120, SCart.Count());
        }
        [TestMethod]
        public void CalcTotPrice()
        {
            ShoppingCart SCart = new ShoppingCart();

            ////1 copy, 1 book
            //SCart.AddToShoppingCart(Utils.GetFirstBook(), 1);
            //Assert.AreEqual<double>(8, Calculator.CalcTotalPrice(SCart));
            //SCart.Items.Clear();

            ////2 copies, 1book
            //SCart.AddToShoppingCart(Utils.GetFirstBook(), 2);
            //Assert.AreEqual<double>(16, Calculator.CalcTotalPrice(SCart));
            //SCart.Items.Clear();

            ////2 different books
            //SCart.AddToShoppingCart(Utils.GetFirstBook(), 1);
            //SCart.AddToShoppingCart(Utils.GetSecondBook(), 1);
            //Assert.AreEqual<double>(15.2, Calculator.CalcTotalPrice(SCart));
            //SCart.Items.Clear();

            ////3 different books
            //SCart.AddToShoppingCart(Utils.GetFirstBook(), 1);
            //SCart.AddToShoppingCart(Utils.GetSecondBook(), 1);
            //SCart.AddToShoppingCart(Utils.GetThirdBook(), 1);
            //Assert.AreEqual<double>(21.6, Calculator.CalcTotalPrice(SCart));
            //SCart.Items.Clear();

            ////4 different books
            //SCart.AddToShoppingCart(Utils.GetFirstBook(), 1);
            //SCart.AddToShoppingCart(Utils.GetSecondBook(), 1);
            //SCart.AddToShoppingCart(Utils.GetThirdBook(), 1);
            //SCart.AddToShoppingCart(Utils.GetFourthBook(), 1);
            //Assert.AreEqual<double>(25.6, Calculator.CalcTotalPrice(SCart));
            //SCart.Items.Clear();

            //5 different books
            SCart.AddToShoppingCart(Utils.GetFirstBook(), 1);
            SCart.AddToShoppingCart(Utils.GetSecondBook(), 1);
            SCart.AddToShoppingCart(Utils.GetThirdBook(), 1);
            SCart.AddToShoppingCart(Utils.GetFourthBook(), 1);
            SCart.AddToShoppingCart(Utils.GetFifthBook(), 1);
            Assert.AreEqual<double>(40, Calculator.CalcTotalPrice(SCart));
            SCart.Items.Clear();

            //5 different books with 2 copies
            SCart.AddToShoppingCart(Utils.GetFirstBook(), 2);
            SCart.AddToShoppingCart(Utils.GetSecondBook(), 2);
            SCart.AddToShoppingCart(Utils.GetThirdBook(), 2);
            SCart.AddToShoppingCart(Utils.GetFourthBook(), 2);
            SCart.AddToShoppingCart(Utils.GetFifthBook(), 2);
            SCart.AddToShoppingCart(Utils.GetFourthBook(), 2);
            Assert.AreEqual<double>(60, Calculator.CalcTotalPrice(SCart));           
            SCart.Items.Clear();
        }
    }
}
