using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Linq.Ch5.Grouping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var cars          = ProcessCars("fuel.csv");
            //var manufacturers = ProcessManufacturers("manufacturer.csv");


        }

        private static object ProcessManufacturers(string file)
        {
            throw new NotImplementedException();
        }

        private static List<Car> ProcessCars(string path)
        {
            var query = from line in File.ReadAllLines(path).Skip(1)
                        where line.Length > 1
                        select TransformToCar(line);

            query.ToList(); // i could return this as well.

            return File.ReadAllLines(path)
                        .Skip(1)
                        .Where(line => line.Length > 1)
                        .ToCar() // Customized way of doing the previous Select. THis is a projection
                        .ToList();
        }

        private static Car TransformToCar(string line)
        {
            var columns = line.Split(',');

            return new Car
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


    /// <summary>
    /// This class is for Extension Methods
    /// </summary>
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
