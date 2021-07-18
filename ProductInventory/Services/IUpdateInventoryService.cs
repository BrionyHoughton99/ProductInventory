using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInventory.Services
{
    public interface IUpdateInventoryService
    {
        Inventory UpdateAgedBrie();
        Inventory UpdateChristmasCrackers();
        Inventory UpdateFreshItem();
        Inventory UpdateFrozenItem();
        Inventory UpdateInvalid();
    }
}
