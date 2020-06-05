using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq.Ch3.Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Queries project!! \n");


            var movies = new List<Movie> 
            { 
                new Movie { Title = "Gone girl", Rating = 4.9f, Year = 1998 },
                new Movie { Title = "Incendies", Rating = 5.9f, Year = 1994 },
                new Movie { Title = "Batman", Rating = 6.9f, Year = 1988 },
                new Movie { Title = "Avengers", Rating = 7.9f, Year = 2008 },
                new Movie { Title = "La que me hice con Flamingo", Rating = 9.9f, Year = 2020 },
            };

            var query1 = movies.Where(m => m.Year > 2000);

            var query2 = from movie in movies
                         where movie.Year > 2000
                         select movie;

            var query3 = movies.Filter<Movie>(m => m.Year > 2000);

            printQuery(query1);
            printQuery(query2);
            printQuery(query3);

            var enumerator = query1.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

        }

        private static void printQuery(IEnumerable<Movie> query)
        {
            Console.WriteLine("Query results:");
            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }
            Console.WriteLine("");
        }
    }
}
