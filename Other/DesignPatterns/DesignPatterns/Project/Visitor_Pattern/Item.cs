using System;

namespace Visitor_Pattern
{
    public class Item
    {
        public int Id { get; set; }
        public double Price { get; set; }

        public Item(int id, double price)
        {
            Id = Id;
            Price = price;
        }

        public double GetDiscount(double percentage)
        {
            return Math.Round(Price * percentage, 2);
        }
    }

    public class Book : Item, IVisitableElement
    {
        public Book(int id, double price) : base(id, price) { }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitBook(this);
        }
    }

    public class Bike : Item, IVisitableElement
    {
        public Bike(int id, double price) : base(id, price) { }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitBike(this);
        }
    }
}
