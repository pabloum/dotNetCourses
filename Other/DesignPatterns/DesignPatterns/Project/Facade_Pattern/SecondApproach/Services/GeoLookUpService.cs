using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern
{
    public class GeoLookUpService
    {
        public string GetCityFromCode(string zipCode)
        {
            return "Medellín";
        }
    }
}
