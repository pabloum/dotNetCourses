using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Pattern
{
    public class VisitorDebug
    {
        public void Debug(bool withVisitor = true)
        {
            if (withVisitor)
            {

                List<object> items = new List<object>
                {
                    new Book(1234, 65.50),
                    new Bike(1234, 400.19),
                    new Book(1234, 53.50),
                    new Book(1234, 19.99),
                };
            }
            else
            {
                Console.WriteLine("Nothing here");
            }
        }
    }
}
