using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWarehouse.Interfaces
{
    internal interface IWarehouse
    {
        bool AddProduct(string factoryName, IProduct product, int amount); // Method for addition to warehouse
        int CurrentUsage {  get; } // Current usage of warehouse
        int Capacity { get; } // Max capacity 

        Dictionary<string, List<IProduct>> TakeProducts(int items); // Dictionary for taken products
        event EventHandler CriticalCapacityReached; // Event for reaching 95% usage
    }
}
