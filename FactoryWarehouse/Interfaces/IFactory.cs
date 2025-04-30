using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWarehouse.Interfaces
{
    internal interface IFactory
    {
        string Name { get; } // Factory Name
        int ProductPerHour { get; } // Production rate
        void Start(); // Method for start
        void Stop(); // Method for stop
    }
}
