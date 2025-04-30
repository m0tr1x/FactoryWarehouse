using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using FactoryWarehouse.Interfaces;

namespace FactoryWarehouse.Warehouse
{

    /// <summary>
    /// Implementation of IWarehouse
    /// </summary>
    internal class Warehouse : IWarehouse
    {
        private readonly ConcurrentDictionary<string, ConcurrentQueue<IProduct>> _products = new();
        private readonly WarehouseMetrics _metrics;
        private int _currentUsage;
        private readonly object _volumeLock = new();

        public event EventHandler CriticalCapacityReached;

        public int CurrentUsage => _currentUsage;
        public int Capacity { get; }

        public Warehouse(WarehouseMetrics metrics, int totalHourlyProduction)
        {
            _metrics = metrics;
            Capacity = _metrics.Multiplier * totalHourlyProduction;
        }
        /// <summary>
        /// Method for add product
        /// </summary>
        /// <param name="factoryName"> Name of factory</param>
        /// <param name="product"> Product </param>
        /// <param name="amount">Amount of product </param>
        /// <returns></returns>

        public bool AddProduct(string factoryName, IProduct product, int amount)
        {
            // locking thread for safe space check
            lock (_volumeLock)
            {
                if (_currentUsage + amount > Capacity)
                    return false; // no space

                _currentUsage += amount;
            }

            // new queue 
            _products.GetOrAdd(factoryName, _ => new ConcurrentQueue<IProduct>());

            // addition
            for (int i = 0; i < amount; i++)
            {
                _products[factoryName].Enqueue(product);
            }

            // check for critical percent of usage
            CriticalCheck();

            Console.WriteLine($"[Warehouse] got {amount}  {product.Name}`s from {factoryName}");
            return true;
        }

        /// <summary>
        /// Method for taking product from warehouse
        /// </summary>
        /// <param name="maxItems"></param>
        /// <returns></returns>
        public Dictionary<string, List<IProduct>> TakeProducts(int maxItems)
        {
            var takenProducts = new Dictionary<string, List<IProduct>>();
            int totalTaken = 0;

            lock (_volumeLock) // locking thread for safe taking
            {
                foreach (var factory in _products.Keys.ToList())
                {
                    while (totalTaken < maxItems && 
                           _products.TryGetValue(factory, out var queue) &&
                           queue.TryDequeue(out var product))
                    {
                        if (!takenProducts.ContainsKey(factory))
                            takenProducts[factory] = new List<IProduct>();

                        takenProducts[factory].Add(product);
                        totalTaken++;
                        _currentUsage--;
                    }
                }
            }

            return takenProducts;
        }
        /// <summary>
        /// Method for check if critical percentage is reached
        /// </summary>
        private void CriticalCheck()
        {
            if ((double)_currentUsage / Capacity >= _metrics.CriticalPercent)
            {
                CriticalCapacityReached?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
