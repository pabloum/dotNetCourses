using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq.Ch2.Features
{
    public static class MyClassWithExtensioMethod 
    {
        // Extension method Example
        static public double MyExtensionMethod(this string data)
        {
            double result = double.Parse(data);
            return result;
        }

        static public int Count<T>(this IEnumerable<T> employees)
        {
            int result = 0;
            foreach (var item in employees)
            {
                result += 1;
            }
            return result;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            LOG("Start execution");

            //Employee[] developers = new Employee[]
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Pablo" },
                new Employee { Id = 2, Name = "Vasco" },
                new Employee { Id = 3, Name = "Pedro" }
            };

            // List<Employee> testers = new List<Employee>
            IEnumerable<Employee> testers = new List<Employee>
            {
                new Employee { Id = 3, Name = "José" },
                new Employee { Id = 4, Name = "Nati" }
            };

            LOG( "The count is " + testers.Count());


            //IEnumerator<Employee> enumerator = ((IEnumerable<Employee>)developers).GetEnumerator();
            IEnumerator<Employee> enumerator = developers.GetEnumerator();

            while (enumerator.MoveNext())
            {
                LOG(enumerator.Current.Name);
            }

            foreach (var employee in developers.Where(e => e.Name.StartsWith("P")) )
            {
                Console.WriteLine(employee.Name);
            }

            LOG("End execution");
        }

        static void LOG(string str)
        {
            Console.WriteLine(str);
        }
    }
}
