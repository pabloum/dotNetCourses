using System;
using Prototype_Pattern;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------- Original order: ---------");
            FoodOrder savedOrder = new FoodOrder("Pablo", 
                                                   false, 
                                                   new string[] {"Pizza", "CocaCola", "Postre"},
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
        }
    }
}
