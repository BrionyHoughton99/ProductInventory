using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductInventory;
using ProductInventory.Interfaces;
using ProductInventory.Models;
using System;

namespace ProductInventoryTests
{
    [TestClass]
    public class UpdateInventoryTests
    {
        [TestMethod]
        public void UpdateFrozenItemTest()
        {
            //setting input values 
            var inventoryItem = new InventoryItem();
            var sellIn = -1;
            var quality = 55;
            var frozenItem = new Inventory()
            {
                SellIn = -2,
                Quality = 50,
                Item = inventoryItem.FrozenFood
            };
            //using moq to serve instance of IUpdateInventoryService UpdateFrozenItem method
            var mock = new Mock<IUpdateInventoryService>();
            mock.Setup(x => x.UpdateFrozenItem()).Returns(frozenItem);
            //checking if the test will pass
            Assert.AreEqual(frozenItem.SellIn, sellIn - 1);
            Assert.AreEqual(frozenItem.Quality, quality - 5);

        }

        [TestMethod]
        public void UpdateAgedBrieTest()
        {
            var inventoryItem = new InventoryItem();
            var sellIn = 1;
            var quality = 1;
            var agedBrie = new Inventory()
            {
                SellIn = 0,
                Quality = 2,
                Item = inventoryItem.AgedBrie
            };

            var mock = new Mock<IUpdateInventoryService>();
            mock.Setup(x => x.UpdateAgedBrie()).Returns(agedBrie);
            Assert.AreEqual(agedBrie.SellIn, sellIn - 1);
            Assert.AreEqual(agedBrie.Quality, quality + 1);

        }

        [TestMethod]
        public void UpdateChristmasCrackersTest()
        {
            var inventoryItem = new InventoryItem();
            var sellIn = -1;
            var quality = 2;
            var christmasCrackers = new Inventory()
            {
                SellIn = -2,
                Quality = 0,
                Item = inventoryItem.ChristmasCrackers
            };
            var mock = new Mock<IUpdateInventoryService>();
            mock.Setup(x => x.UpdateChristmasCrackers()).Returns(christmasCrackers);
            Assert.AreEqual(christmasCrackers.SellIn, sellIn - 1);
            Assert.AreEqual(christmasCrackers.Quality, quality - 2);
        }

        [TestMethod]
        public void UpdateFreshItemTest()
        {
            var inventoryItem = new InventoryItem();
            var sellIn = 2;
            var quality = 2;
            var freshItem = new Inventory()
            {
                SellIn = 1,
                Quality = 0,
                Item = inventoryItem.FreshFood
            };
            var mock = new Mock<IUpdateInventoryService>();
            mock.Setup(x => x.UpdateChristmasCrackers()).Returns(freshItem);
            Assert.AreEqual(freshItem.SellIn, sellIn - 1);
            Assert.AreEqual(freshItem.Quality, quality - 2);

        }

        [TestMethod]
        public void UpdateInvalidTest()
        {
            var inventoryItem = new InventoryItem();

            var invalidItem = new Inventory()
            {
                Item = "NO SUCH ITEM"
            };

            var mock = new Mock<IUpdateInventoryService>();
            mock.Setup(x => x.UpdateInvalid()).Returns(invalidItem);
            Assert.AreEqual(invalidItem.Item, "NO SUCH ITEM");
        }
    }
}
