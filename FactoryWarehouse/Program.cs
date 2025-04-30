using FactoryWarehouse.Interfaces;
using FactoryWarehouse.Product;
using FactoryWarehouse.Truck;
using FactoryWarehouse.Warehouse;

namespace FactoryWarehouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var metrics = new WarehouseMetrics();
           int n = 50;
           int factoryNum = 3;
           double totalRate = (n + 1.1 * n + 1.2 * n);

           var warehouse = new Warehouse.Warehouse(metrics, (int)totalRate);
           var creator = new Creator();
           var observer = new WarehouseObs(warehouse);

            var factories = new List<IFactory>();
            for(int i = 0; i < factoryNum; ++i)
            {
                var name = ((char)('A' + i)).ToString();
                var rate = (int)(n * (1 + i + 0.1));
                factories.Add(new Factory.Factory(name, rate,warehouse,creator));
            }

            var trucks = new List<ITruck>
            {
                new SmallTruck(warehouse),
                new LargeTruck(warehouse)
            };

            warehouse.CriticalCapacityReached += (sender, e) =>
            {
                Console.WriteLine("[System] Warehouse usage is 95% calling for trucks");
                foreach (var truck in trucks)
                {
                    truck.StartDelivery();
                }
            };

            observer.Start();
            foreach(var factory in factories) { factory.Start(); }
            Console.WriteLine("System is running press enter to stop");
            Console.ReadLine();

            foreach(var factory in factories) { factory.Stop(); }
            foreach(var truck in trucks) {  truck.StopDelivery(); }
      

        }
    }
}
