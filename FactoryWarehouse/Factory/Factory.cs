using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryWarehouse.Interfaces;

namespace FactoryWarehouse.Factory
{
    /// <summary>
    /// Implementation of factory
    /// </summary>
    internal class Factory : IFactory
    {
        private readonly string _name;
        private readonly int _productPerHour;
        private readonly IWarehouse _warehouse;
        private readonly IProductCreator _productCreator;
        private Thread _workingThread; 
        private bool _isWorking;
        public string Name => _name;
        public int ProductPerHour => _productPerHour;
        public Factory(string name, int productPerHour,
            IWarehouse warehouse, IProductCreator productCreator)
        {
            _name = name;
            _productPerHour = productPerHour;
            _warehouse = warehouse;
            _productCreator = productCreator;
        }
        /// <summary>
        /// Method for starting factory
        /// </summary>
        public void Start()
        {
            _isWorking = true;
            _workingThread = new Thread(Work);
            _workingThread.Start();
        }
        /// <summary>
        /// Method for stopping factory
        /// </summary>
        public void Stop()
        {
            _isWorking = false;
            _workingThread?.Join();
        }
        /// <summary>
        /// Core method of factory working
        /// </summary>
        public void Work()
        {
            while (_isWorking)
            {
                var product = _productCreator.CreateProduct(_name);
                while(!_warehouse.AddProduct(_name, product, _productPerHour))
                {
                    Thread.Sleep(1000); // pause for optimisation
                }
                Thread.Sleep(1000); // pause for optimisation
            }

        }
    }
}
