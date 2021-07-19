using Microsoft.Extensions.DependencyInjection;
using ProductInventory.Interfaces;
using ProductInventory.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInventory
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            //using configureservice class to create instances of services for dependency injection through out app
            //these are called in Program class
            var services = new ServiceCollection();

            services.AddTransient<InventoryTableService>();
            services.AddTransient<IUpdateInventoryService, UpdateInventoryService>();
            services.AddTransient<InventoryTableService>();
            services.AddTransient<BackgroundTaskService>();

            return services;
        }
    }
}
