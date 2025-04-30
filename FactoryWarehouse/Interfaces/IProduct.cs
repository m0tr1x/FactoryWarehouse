using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWarehouse.Interfaces
{
    internal interface IProduct
    {
        /// <summary>
        /// Interface for product
        /// </summary>
        string Name { get; } // Name of product
        double Weight { get; } // Weight of product
        string PackegeType { get; } // Type of product

    }
}
