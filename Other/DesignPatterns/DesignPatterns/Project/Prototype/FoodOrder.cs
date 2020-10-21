using System;
using System.Collections.Generic;

namespace Prototype_Pattern
{
    public abstract class Prototype
    {
        public abstract Prototype ShallowCopy();
        public abstract Prototype DeepCopy();
        public abstract void Debug();
    }
    public class OrderInfo
    {
        public int Id { get; set; }
        public OrderInfo(int id)
        {
            Id = id;
        }
    }
    public class FoodOrder : Prototype
    {
        public string CustomerName { get; set; }
        public bool IsDelivery { get; set; }
        public string[] OrderContents { get; set; }
        public OrderInfo OrderInfo { get; set; }

        public FoodOrder(string name, bool delivery, string[] contents, OrderInfo orderInfo)
        {
            CustomerName = name;
            IsDelivery = delivery;
            OrderContents = contents;
            OrderInfo = orderInfo;
        }

        public override Prototype ShallowCopy()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public override Prototype DeepCopy()
        {
            var cloned = (FoodOrder)this.MemberwiseClone();
            cloned.OrderInfo = new OrderInfo(this.OrderInfo.Id);
            return cloned;
        }

        public override void Debug()
        {
            Console.WriteLine("--------------- Prototype Order ---------------");
            Console.WriteLine($"\n Name: {CustomerName} \n Delivery: {IsDelivery}");
            Console.WriteLine($" Order info Id: {OrderInfo.Id}");
            Console.WriteLine(" Order Contents: " + string.Join(",", OrderContents) + "\n" );
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }

    public class PrototypeManager
    {
        private Dictionary<string, Prototype> _protypeLibrary = Dictionary<string, Prototype>;

        public Prototype this[string key]
        {
            get { return _protypeLibrary[key]; }
            set { _protypeLibrary.Add(key, value); }
        }
    }
}
