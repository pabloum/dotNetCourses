﻿using System;
using System.Collections.Generic;

namespace Linq.Ch2.Features
{
    class Program
    {
        static void Main(string[] args)
        {
            LOG("Start execution");

            //Employee[] developers = new Employee[]
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Pablo" },
                new Employee { Id = 2, Name = "Vasco" }
            };

            // List<Employee> testers = new List<Employee>
            IEnumerable<Employee> testers = new List<Employee>
            {
                new Employee { Id = 3, Name = "José" },
                new Employee { Id = 4, Name = "Nati" }
            };

            //IEnumerator<Employee> enumerator = ((IEnumerable<Employee>)developers).GetEnumerator();
            IEnumerator<Employee> enumerator = developers.GetEnumerator();

            while (enumerator.MoveNext())
            {
                LOG(enumerator.Current.Name);
            }

            LOG("End execution");
        }

        static void LOG(string str)
        {
            Console.WriteLine(str);
        }
    }
}
