using ProductInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductInventory.Services
{
    public class UpdateInventoryService : IUpdateInventoryService
    {

        public Inventory UpdateFrozenItem()
        {
            var inventoryItem = new InventoryItem();

            var frozenItem = new Inventory()
            {
                SellIn = -1,
                Quality = 55,
                Item = inventoryItem.FrozenFood
            };


            if (frozenItem.Item == "Frozen Foods")
            {
                if (frozenItem.SellIn <= 0)
                {
                    frozenItem.SellIn--;
                    frozenItem.Quality = frozenItem.Quality - 5;
                } else
                {
                    frozenItem.SellIn--;
                    frozenItem.Quality--;
                }

            }
            return frozenItem;
        }

        public Inventory UpdateAgedBrie()
        {
            var inventoryItem = new InventoryItem();
            var agedBrie = new Inventory()
            {
                SellIn = 1,
                Quality = 1,
                Item = inventoryItem.AgedBrie
            };

            if (agedBrie.Item == "Aged Brie")
            {
                agedBrie.SellIn--;
                agedBrie.Quality++;

            }
            return agedBrie;
        }

        public Inventory UpdateChristmasCrackers()
        {
            var inventoryItem = new InventoryItem();
            var christmasCrackers = new Inventory()
            {
                SellIn = -1,
                Quality = 2,
                Item = inventoryItem.ChristmasCrackers
            };

            if (christmasCrackers.Item == "Christmas Crackers")
            {
                DateTime christmasTenDays = new DateTime(2021, 12, 15);
                DateTime christmasFiveDays = new DateTime(2021, 12, 20);

                if (christmasTenDays == DateTime.Now)
                {
                    christmasCrackers.SellIn--;
                    christmasCrackers.Quality -= 2;
                }
                else if (christmasFiveDays == DateTime.Now)
                {

                    christmasCrackers.SellIn--;
                    christmasCrackers.Quality -= 3;
                }
                else
                {
                    christmasCrackers.SellIn--;
                    christmasCrackers.Quality -= 2;
                }

            }
            return christmasCrackers;
        }

        public Inventory UpdateFreshItem()
        {
            var inventoryItem = new InventoryItem();
            var freshItem = new Inventory()
            {
                SellIn = -1,
                Quality = 5,
                Item = inventoryItem.FreshFood
            };
            if(freshItem.Item =="Fresh Foods")
            {
                if (freshItem.SellIn <= 0)
                {
                    freshItem.SellIn--;
                    freshItem.Quality -= 4;
                }
                else
                {
                    freshItem.SellIn--;
                    freshItem.Quality -= 2;
                }
            }
            return freshItem;
        }
        public Inventory UpdateInvalid()
        {
            var inventoryItem = new InventoryItem();
            var invalidItem = new Inventory()
            {
                Item = inventoryItem.InvalidItem
            };
            if (invalidItem.Item == "Invalid Item")
            {
                invalidItem.Item = "NO SUCH ITEM";
            }
            return invalidItem;
        }
    }

}
