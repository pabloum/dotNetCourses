using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Pattern
{
    public class ObjectStructure
    {
        private List<IVisitableElement> _cart;
        public ObjectStructure(List<IVisitableElement> items)
        {
            _cart = items;
        }

        public void RemoveItem(IVisitableElement item)
        {
            _cart.Remove(item);
        }

        public void ApplyVisitor(IVisitor visitor)
        {
            Console.WriteLine("\n-------- Visitor breakdown ---------");

            foreach (var item in _cart)
            {
                item.Accept(visitor);
            }

            visitor.Print();
        }
    }
}
