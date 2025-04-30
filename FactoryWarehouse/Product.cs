using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryWarehouse.Interfaces;

namespace FactoryWarehouse
{
    /// <summary>
    /// Impletmentation of IProduct
    /// </summary>
    internal class Product : IProduct
    {
        public string Name { get; }

        public double Weight { get; }

        public string PackegeType { get; }
        public Product(string name, double weight, string packegeType)
        {
            Name = name;
            Weight = weight;
            PackegeType = packegeType;
        }
    }
}
