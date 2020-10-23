using System;
using Facade_Pattern;
using Prototype_Pattern;
using Visitor_Pattern;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestPrototype();
            //TestFacade();
            TestVisitor();
        }

        static void TestPrototype()
        {
            Console.WriteLine("--------- Original order: ---------");
            FoodOrder savedOrder = new FoodOrder("Pablo",
                                                   false,
                                                   new string[] { "Pizza", "CocaCola", "Postre" },
                                                   new OrderInfo(1234));
            savedOrder.Debug();


            Console.WriteLine("--------- Clone order: ---------");
            FoodOrder clonedOrder = (FoodOrder)savedOrder.DeepCopy();
            clonedOrder.Debug();


            Console.WriteLine("--------- Order changes ---------");
            savedOrder.CustomerName = "Álvaro";
            savedOrder.OrderInfo.Id = 999999;

            savedOrder.Debug();
            clonedOrder.Debug();


            Console.WriteLine("--------- Prototype Manager ---------");
            PrototypeManager prototypeManager = new PrototypeManager();

            prototypeManager["21/10/2020"] = new FoodOrder("Verónica",
                                                           true,
                                                           new string[] { "sushi", "agua" },
                                                           new OrderInfo(9995));
            Console.WriteLine("Mnager clone: ");
            FoodOrder managerOrder = (FoodOrder)prototypeManager["21/10/2020"].DeepCopy();
            managerOrder.Debug();
        }

        static void TestFacade()
        {
            //Facade.DebugFirstApproach();
            Facade.DebugSecondApproach();
        }

        static void TestVisitor()
        {
            VisitorDebug.Debug();
        }
    }
}
