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
            Assert.AreEqual<int>(101, SCart.Items.Count);
        }
    }
}
