using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWarehouse.Warehouse
{
    internal class WarehouseMetrics
    {
        public double CriticalPercent { get; set; } = 0.95;
        public int Multiplier { get; set; } = 100;

    }
}
