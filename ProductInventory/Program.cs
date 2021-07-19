using Microsoft.Extensions.DependencyInjection;
using ProductInventory.Interfaces;
using ProductInventory.Services;
using System;

namespace ProductInventory
{
    class Program
    {
        public static void Main(String[] args)
        {
            //using dependency injection to configure services
            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<InventoryTableService>().Run(args);
            serviceProvider.GetService<IUpdateInventoryService>();
            serviceProvider.GetService<InventoryTableService>();
            serviceProvider.GetService<BackgroundTaskService>();

        }
    }
}
