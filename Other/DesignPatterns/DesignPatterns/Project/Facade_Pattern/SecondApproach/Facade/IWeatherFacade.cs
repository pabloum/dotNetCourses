using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern
{
    public interface IWeatherFacade
    {
        string GetTemperatureFromZip(string zipCode);
    }
}
