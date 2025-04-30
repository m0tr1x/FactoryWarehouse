using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryWarehouse.Interfaces;

namespace FactoryWarehouse.Warehouse
{
    /// <summary>
    /// Class for observing condiiton of warehouse
    /// </summary>
    internal class WarehouseObs
    {
        private readonly IWarehouse _warehouse;
        private Thread _monitorThread;
        private bool _isRunning;

        public WarehouseObs(IWarehouse warehouse)
        {
            _warehouse = warehouse;
        }
        public void Start()
        {
            _isRunning = true;
            _monitorThread = new Thread(Observe);
            _monitorThread.Start();
        }
        public void Stop()
        {
            _isRunning = false;
            _monitorThread?.Join();
        }
        private void Observe()
        {
            while (_isRunning)
            {
                Console.WriteLine($"\n[Монитор] Склад: {_warehouse.CurrentUsage}/{_warehouse.Capacity} " +
                                $"({100.0 * _warehouse.CurrentUsage / _warehouse.Capacity:F1}%)\n");
                Thread.Sleep(5000);
            }
        }

    }
}
