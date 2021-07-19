using ProductInventory.Interfaces;
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
            //setting input values
            var inventoryItem = new InventoryItem();
            var frozenItem = new Inventory()
            {
                SellIn = -1,
                Quality = 55,
                Item = inventoryItem.FrozenFood
            };
            //looking if there is the item in the table when running app
            if (frozenItem.Item == "Frozen Foods")
            {
                //setting logic if the Sell By date is 0 to reduce the quality by 5 and sell buy date by 1
                if (frozenItem.SellIn <= 0)
                {
                    frozenItem.SellIn--;
                    frozenItem.Quality -= 5;
                } else
                {
                    //if Sell By date is not 0 then reduce Sell By and Quality by 1
                    frozenItem.SellIn--;
                    frozenItem.Quality--;
                }

            }
            return frozenItem;
        }

        public Inventory UpdateAgedBrie()
        {
            //setting input values
            var inventoryItem = new InventoryItem();
            var agedBrie = new Inventory()
            {
                SellIn = 1,
                Quality = 1,
                Item = inventoryItem.AgedBrie
            };

            if (agedBrie.Item == "Aged Brie")
            {
                //adding logic if there is an item in the table for aged brie, decrease Sell By date but increase Quality
                agedBrie.SellIn--;
                agedBrie.Quality++;

            }
            return agedBrie;
        }

        public Inventory UpdateChristmasCrackers()
        {
            //setting input values
            var inventoryItem = new InventoryItem();
            var christmasCrackers = new Inventory()
            {
                SellIn = -1,
                Quality = 2,
                Item = inventoryItem.ChristmasCrackers
            };

            //checking if there is an item in the table for christmas crackers
            if (christmasCrackers.Item == "Christmas Crackers")
            {
                //setting variables to add logic around christmas time
                DateTime christmasTenDays = new DateTime(2021, 12, 15);
                DateTime christmasFiveDays = new DateTime(2021, 12, 20);
                DateTime christmas = new DateTime(2021, 12, 25);

                if (christmasTenDays == DateTime.Now)
                {
                    //checking if date is christmasTenDays to decrease Sell By date but increase Quality by 2
                    christmasCrackers.SellIn--;
                    christmasCrackers.Quality += 2;
                }
                else if (christmasFiveDays == DateTime.Now)
                {
                    //checking if date is christmasFiveDays to decrease sell by date but increase quality by 3
                    christmasCrackers.SellIn--;
                    christmasCrackers.Quality += 3;
                }
                else if (christmas < DateTime.Now)
                {
                    //if christmas has been then Quality is 0
                    christmasCrackers.SellIn--;
                    christmasCrackers.Quality = 0;
                }
                else 
                {
                    //if date is not approaching christmas then Quality decreases by 2
                    christmasCrackers.SellIn--;
                    christmasCrackers.Quality -= 2;
                }

            }
            return christmasCrackers;
        }

        public Inventory UpdateFreshItem()
        {
            //setting input values
            var inventoryItem = new InventoryItem();
            var freshItem = new Inventory()
            {
                SellIn = -1,
                Quality = 5,
                Item = inventoryItem.FreshFood
            };
            //checking if there is a fresh food item in the table
            if(freshItem.Item =="Fresh Foods")
            {
                if (freshItem.SellIn <= 0)
                {
                    //checking if the sell buy date is 0, decrease Quality twice as fast
                    freshItem.SellIn--;
                    freshItem.Quality -= 4;
                }
                else
                {
                    //if sell buy date is more than 0 then decrease quality by 2
                    freshItem.SellIn--;
                    freshItem.Quality -= 2;
                }
            }
            return freshItem;
        }
        public Inventory UpdateInvalid()
        {
            //setting input values
            var inventoryItem = new InventoryItem();
            var invalidItem = new Inventory()
            {
                Item = inventoryItem.InvalidItem
            };
            //checking if there is an item in the table for Invalid Item
            if (invalidItem.Item == "Invalid Item")
            {
                // return NO SUCH ITEM
                invalidItem.Item = "NO SUCH ITEM";
            }
            return invalidItem;
        }
    }

}
