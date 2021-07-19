﻿using ConsoleTables;
using ProductInventory.Interfaces;
using ProductInventory.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInventory
{
    public class InventoryTableService
    {
        // setting up dependencies of other service classes to allow use of methods
        #region Private Properties
        private readonly IUpdateInventoryService _updateInventoryService;
        #endregion

        #region Constructors
        public InventoryTableService(IUpdateInventoryService _updateInventoryService)
        {
            this._updateInventoryService = _updateInventoryService;
        }
        #endregion

        

        public IEnumerable<Inventory> GetInventoryItems()
        {
            //configure service class 
            var frozenItem = _updateInventoryService.UpdateFrozenItem();
            var agedbrie = _updateInventoryService.UpdateAgedBrie();
            var christmasCracker = _updateInventoryService.UpdateChristmasCrackers();
            var freshItem = _updateInventoryService.UpdateFreshItem();
            var invalidItem = _updateInventoryService.UpdateInvalid();

            //this is used to iterate the IEnumerable object and used with return keyword used to create the table in run method
            yield return new Inventory
            {
                //calling properties from service class
                Item = agedbrie.Item,
                SellIn = agedbrie.SellIn,
                Quality = agedbrie.Quality
            };
            yield return new Inventory
            {
                Item = christmasCracker.Item,
                SellIn = christmasCracker.SellIn,
                Quality = christmasCracker.Quality

            };
            yield return new Inventory
            {
                Item = "Soap",
                SellIn = 2,
                Quality = 2
            };
            yield return new Inventory
            {
                Item = frozenItem.Item,
                SellIn = frozenItem.SellIn,
                Quality = frozenItem.Quality
            };
            yield return new Inventory
            {
                Item = freshItem.Item,
                SellIn = freshItem.SellIn,
                Quality = freshItem.Quality
            };
            yield return new Inventory
            {
                Item = invalidItem.Item
            };
        }
        //Run class is called in program class for showing table of inventorys when running the app
        public void Run(String[] args)
        {
            // setting an instance of the InventoryTableService object to call and write to console table
            var inventoryTable = new InventoryTableService(_updateInventoryService);
            ConsoleTable.
                From(inventoryTable.GetInventoryItems())
                .Write();
        }
    }
}
