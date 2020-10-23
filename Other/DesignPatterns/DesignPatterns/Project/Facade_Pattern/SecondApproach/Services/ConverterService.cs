using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern
{
    public class ConverterService
    {
        public int ConvertFarenheitToCelcius(int temperature)
        {
            return ((temperature -32) * 5/9);
        }
    }
}
