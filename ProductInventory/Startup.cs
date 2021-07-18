using Microsoft.Extensions.DependencyInjection;
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
            //creating an instance of the table class for calling in program class using dependency injection
            var services = new ServiceCollection();

            services.AddTransient<InventoryTableService>();
            services.AddTransient<IUpdateInventoryService, UpdateInventoryService>();
            services.AddTransient<InventoryTableService>();
            services.AddTransient<BackgroundTaskService>();

            return services;
        }
    }
}
