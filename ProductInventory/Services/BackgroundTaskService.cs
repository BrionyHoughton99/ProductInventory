using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductInventory.Services
{
    public class BackgroundTaskService : IHostedService
    {
        #region Private Properties
        private readonly InventoryTableService _inventoryTableService;
        private Timer _timer;

        #endregion

        #region Constructors
        public BackgroundTaskService(InventoryTableService _inventoryTableService)
        {
            this._inventoryTableService = _inventoryTableService;

        }
        #endregion

        //using IHostedService to run task every 24 hours by setting timer
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(
                runTask,
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(5.0)
            );
            return Task.CompletedTask;

        }
        //can call StopAsync from within application to 
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void runTask(object state)
        {
            _inventoryTableService.GetInventoryItems();
        }
    }
}
