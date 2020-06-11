using Linq.Ch4.Cars;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Linq.Ch5.Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program will read a CSV and save it into the Enitty.\n");

            var cars = ProcesFile("fuel.csv");

            // Sort the most fuel efficient cars.
            var query = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                            .OrderByDescending(car => car.Combined)
                            .ThenBy(car => car.Name) // This is a secondary option for ordering. Do not use OrderBy again for a secondary order.
                            .Select(c => new { // This is an anonymous type.  
                                Manufacturer = c.Manufacturer,
                                c.Name, // Shortcut. No need to use the name. COmpiler just undertands to use the same name
                                c.Combined
                            });


            var query2 = from car in cars
                         where car.Manufacturer == "BMW" && car.Year == 2016
                         orderby car.Combined descending, car.Name ascending/*, a third option... etc*/
                         // select car;
                         select new { // This is an anonymous type.  
                             Manufacturer = car.Manufacturer,
                             car.Name, // Shortcut. No need to use the name. COmpiler just undertands to use the same name
                             car.Combined
                         };

            var top = query.First(); // not available in query syntax
            var top2 = query.First(c => c.Cylinders > 6); // not available in query syntax. This brings the first value it finds that fullfils that condition
                                                          // Exception might be thrown if no condition is found.    
            var top3 = query.FirstOrDefault(c => c.Cylinders > 6); // not available in query syntax. This brings the first value it finds that fullfils that condition
                    // default would be null if nothing is found

                
            var last = query.Last(); // This is the last 
            var last2 = query.Last(c => c.Cylinders < 6); // This is the last 


            // These methods do not offer deferred execution, but they are as lazy as possible. 
            var ask  = cars.Any(); // Is there anything in this dataset? Is there at least one thing here.
            var ask2 = cars.Any(c => c.Manufacturer == "Ford"); //
            var ask3 = cars.All(c => c.Manufacturer == "Ford"); //
            // var ask4 = cars.Contains(c => c.Manufacturer == "Ford"); // did not compile


            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"The car {car.Name} has a combined fuel efficiency of {car.Combined}");
            }
        }

        private static List<Car> ProcesFile(string path)
        {
            var query = from line in File.ReadAllLines(path).Skip(1)
                        where line.Length > 1
                        select TransformToCar(line);
                        // ToList() wouldnt work here

            query.ToList(); // i could return this as well.

            return File.ReadAllLines(path)
                        .Skip(1)
                        .Where(line => line.Length > 1)
                        //.Select(TransformToCar)
                        //.Select(l => TransformToCar(l))
                        .ToCar() // Customized way of doing the previous Select. THis is a projection
                        .ToList();           
        }

        private static Car TransformToCar(string line)
        {
            var columns = line.Split(',');

            return new Car {
                Year = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
                Displacement = double.Parse(columns[3]),
                Cylinders = int.Parse(columns[4]),
                City = int.Parse(columns[5]),
                Highway = int.Parse(columns[6]),
                Combined = int.Parse(columns[7])
            };
        }
    }

    public static class MyLinqExtension
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
    }

}
