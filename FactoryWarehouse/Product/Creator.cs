using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryWarehouse.Interfaces;

namespace FactoryWarehouse.Product
{
    /// <summary>
    /// Implementation of IProductCreator
    /// </summary>
    internal class Creator : IProductCreator
    {
        private readonly Random _random = new();
        public IProduct CreateProduct(string factoryName)
        {
            return new Product(factoryName, _random.NextDouble(), "box");
        }
    }
}
