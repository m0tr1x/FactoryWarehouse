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

    internal class SmallTruck : BaseTruck
    {
        public SmallTruck(IWarehouse warehouse): base(warehouse, "Small Truck", 50) { }
    }
}
