using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Pattern
{
    public interface IVisitor
    {
        void VisitBook(Book book);
        void VisitBike(Bike bike);
        void Print();
    }

    public interface IVisitableElement
    {
        void Accept(IVisitor visitor);
    }

    public class DiscountVisitor : IVisitor
    {
        private double _savings;
        public void VisitBike(Bike bike)
        {
            double discount = 0.0;

            if (bike.Price < 200.00)
            {
                discount = bike.GetDiscount(0.10);
                Console.WriteLine($"DISCOUNTED: Bike #{bike.Id} is now {bike.Price - discount}");
            }
            else
            {
                Console.WriteLine($"FULL PRICE: Bike {bike.Id} is {bike.Price}");
            }
            _savings += discount;
        }

        public void VisitBook(Book book)
        {
            double discount = book.GetDiscount(0.10);
            Console.WriteLine($"SUPER SAVINGS: Book {book.Id} is now {book.Price - discount}");
            _savings += discount;
        }

        public void Print()
        {
            Console.WriteLine($"\n You saved a total of {_savings} on today's orders");
        }
    }

    public class SalesVisitor : IVisitor
    {
        private int BookCount;
        private int BikeCount;

        public void Print()
        {
            Console.WriteLine($"\n You sold {BookCount + BikeCount} items today: {BookCount} books and {BikeCount} bikes");
        }

        public void VisitBike(Bike bike)
        {
            BikeCount++;
        }

        public void VisitBook(Book book)
        {
            BookCount++;
        }
    }
}
