namespace Facade_Pattern
{
    public class WeatherFacade : IWeatherFacade
    {
        public GeoLookUpService GeoService { get; set; }
        public WeatherService WeatherService { get; set; }
        public ConverterService ConverterService { get; set; }

        public WeatherFacade()
        {
            GeoService = new GeoLookUpService(); ;
            WeatherService = new WeatherService();
            ConverterService = new ConverterService();
        }

        public string GetTemperatureFromZip(string zipCode)
        {
            var city = GeoService.GetCityFromCode(zipCode);
            var temperature = WeatherService.GetTempFarenheit(city);
            var celcius = ConverterService.ConvertFarenheitToCelcius(temperature);

            return $"The temperature in the city {city} is {celcius}°C";
        }
    }
}
