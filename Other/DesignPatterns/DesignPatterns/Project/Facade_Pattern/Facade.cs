using System;

namespace Facade_Pattern
{
    public class Facade
    {
        static public void DebugFirstApproach(bool withFacade = true)
        {
            if (withFacade)
            {
                BigClassFacade bigClassFacade = new BigClassFacade();
                bigClassFacade.IncrementByValue(4);
                bigClassFacade.DecrementByValue(5);
            }
            else
            {
                // We do not want this structure
                BigClass bigClass = new BigClass();
                bigClass.SetValue(3);
                bigClass.IncrementI();
                bigClass.IncrementI();
                bigClass.IncrementI();
                bigClass.DecrementI();
            }
        }

        static public void DebugSecondApproach(bool withFacade = true)
        {
            if (withFacade)
            {
                var zipCode = "050030";

                IWeatherFacade weatherFacade = new WeatherFacade();
                string result = weatherFacade.GetTemperatureFromZip(zipCode);

                Console.WriteLine(result);
            }
            else
            {
                // We do not want this structure
                var zipCode = "050030";

                // Call to service 1
                var geoService = new GeoLookUpService();
                var city= geoService.GetCityFromCode(zipCode);

                // Call to service 2
                var weatherService = new WeatherService();
                var temperature = weatherService.GetTempFarenheit(city);

                // Call to service 3
                var metricConverterService = new ConverterService();
                var celcius = metricConverterService.ConvertFarenheitToCelcius(temperature);

                Console.WriteLine($"The temperature in the city {city} is {celcius}°C");
            }

        }
    }
}
