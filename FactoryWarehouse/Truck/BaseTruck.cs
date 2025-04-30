using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryWarehouse.Interfaces;

namespace FactoryWarehouse.Truck
{
    internal abstract class BaseTruck : ITruck
    {
        /// <summary>
        /// Base abstract class for trucs
        /// </summary>
        protected readonly IWarehouse _warehouse; // Link for warehouse
        private Thread _delivery; // delivery thread
        private bool _isRunning; // flag for thread

        public string Name { get; } // Name

        public int Capacity { get; } // Capacity

        /// <summary>
        /// Truck Constructor
        /// </summary>
        /// <param name="warehouse"> Warehouse </param>
        /// <param name="name">Truck name </param>
        /// <param name="capacity">Truck capacity </param>
        protected BaseTruck(IWarehouse warehouse, string name, int capacity)
        {
            _warehouse = warehouse;
            Name = name;
            Capacity = capacity;
        }

        public void StartDelivery()
        {
            _isRunning = true;
            _delivery = new Thread(Deliver);
            _delivery.Start();
        }

        public void StopDelivery()
        {
            _isRunning = false;
            _delivery?.Join();
        }
        /// <summary>
        /// Method for delivery
        /// </summary>
        private void Deliver()
        {
            while (_isRunning)
            {
                Thread.Sleep(1000); // pause for polling optimisation

                var products = _warehouse.TakeProducts(Capacity); 
                if (products.Count > 0)
                {
                    int totalItems = products.Sum(p => p.Value.Count);
                    Console.WriteLine($"[{Name}] took {totalItems} items:");

                    foreach (var (factory, items) in products)
                    {
                        Console.WriteLine($"  - {items.Count} from {factory}");
                    }
                }
            }
        }
    }
}

