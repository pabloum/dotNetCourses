using System;
using System.Collections.Generic;
using System.Text;

namespace Linq.Ch3.Queries
{
    public class Movie
    {
        public string Title { get; set; }
        public float Rating { get; set; }

        int _year;
        public int Year 
        {
            get 
            {
                Console.WriteLine($"Returning {_year} from {Title}");
                return _year;
            }

            set 
            {
                _year = value;
            } 
        }
    }
}
