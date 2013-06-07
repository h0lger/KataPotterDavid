using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataPotterLib.Model;


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
                    (100 * i),
                    "TestBook",
                    Guid.NewGuid().ToString(),
                    "Harry");
                SCart.Items.Add(tmpBook);
            }
            Assert.AreEqual<int>(100, SCart.Items.Count);
        }
        [TestMethod]
        public void CalcTotPrice()
        {
            ShoppingCart SCart = new ShoppingCart();

            //Book 1
            SCart.Items.Add(
                new Book(8, "Deathly Hallows", Guid.NewGuid().ToString(), "Rowling"));
            //Book 2
            SCart.Items.Add(
                new Book(8, "Half-blood Prince", Guid.NewGuid().ToString(), "Rowling"));

            double totPrice = Calculator.CalcTotalPrice(SCart);

            Assert.AreEqual<double>(16, totPrice);
        }
    }
}
