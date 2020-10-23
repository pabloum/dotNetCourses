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

            var objectStructure = new ObjectStructure(items);

            var discountVisitor = new DiscountVisitor();
            var salesVisitor = new SalesVisitor();

            objectStructure.ApplyVisitor(discountVisitor);
            objectStructure.ApplyVisitor(salesVisitor);
        }
    }
}
