using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryWarehouse.Interfaces;

namespace FactoryWarehouse.Truck
{
    /// <summary>
    /// Implementation of base truck
    /// </summary>
    internal class LargeTruck : BaseTruck
    {
        public LargeTruck(IWarehouse warehouse) : base(warehouse, "Large Truck", 200)
        {
        }
    }
}
