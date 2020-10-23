using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Pattern
{
    public class VisitorDebug
    {
        public static void Debug()
        {
            List<IVisitableElement> items = new List<IVisitableElement>
            {
                new Book(123, 65.50),
                new Bike(234, 400.19),
                new Book(124, 53.50),
                new Book(134, 19.99),
            };

            var discountVisitor = new DiscountVisitor();

            foreach (var item in items)
            {
                item.Accept(discountVisitor);
            }

            discountVisitor.Print();

            var salesVisitor = new SalesVisitor();
            foreach (var item in items)
            {
                item.Accept(salesVisitor);
            }

            salesVisitor.Print();
        }
    }
}
