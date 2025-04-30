using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWarehouse.Interfaces
{
    internal interface ITruck
    {
        string Name { get; } // Truck name
        int Capacity { get;  } // Capacity of truck
        void StartDelivery(); // Method for start delivery
        void StopDelivery(); // Method for start delivery
    }
}
