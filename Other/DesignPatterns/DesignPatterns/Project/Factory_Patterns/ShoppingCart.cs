using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Patterns
{
    public class ShoppingCart
    {
        public Order Order { get; }

        public ShoppingCart(Order order)
        {
            Order = order;
        }

        public string Finalize()
        {
            var shippingProvider = ShippingProviderFactory.CreateShippingProvider(Order.Country);
            Order.ShippingStatus = ShippingStatus.ReadyForShipment;

            return shippingProvider.GenerateShippingLabelFor(Order);
        }
    }
}
