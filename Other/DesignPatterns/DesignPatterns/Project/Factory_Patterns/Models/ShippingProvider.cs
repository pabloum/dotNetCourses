using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Patterns
{
    public class ShippingProvider
    {
        public string GenerateShippingLabelFor(Order order)
        {
            return "Label";
        }
    }
}
