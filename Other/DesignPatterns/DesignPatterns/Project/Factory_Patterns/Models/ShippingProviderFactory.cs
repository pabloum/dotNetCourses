using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Patterns
{
    public static class ShippingProviderFactory
    {
        public static ShippingProvider CreateShippingProvider(string country)
        {
            return new ShippingProvider();
        }
    }
}
