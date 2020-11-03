using System;

namespace Factory_Patterns
{
    public static class Factory
    {
        public static void DebugSimpleFactory()
        {
            var order = new Order();

            var cart = new ShoppingCart(order);
            var shippingLabel = cart.Finalize();


            Console.WriteLine(shippingLabel);
        }

        public static void DebugMethodFactory()
        {

        }

        public static void DebugAbstractFactory()
        {

        }
    }
}
