using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWarehouse.Interfaces
{
    internal interface IProductCreator
    {
        IProduct CreateProduct(string factoryName); // Method for creation product
    }
}
