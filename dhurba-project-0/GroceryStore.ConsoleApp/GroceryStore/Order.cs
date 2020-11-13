using System;
using System.Collections.Generic;

namespace GroceryStore
{
    public class Order
    {
        List<Order> customerOrder = new List<Order>();
        //list of all customer order
        Dictionary<int,List<Order>>listsOfAllCustomerOrder=new Dictionary<int,List<Order>>();

        public int Ssn { get; }
        public string Name { get; }
        public int Quantity { get; }

        public double TotalPrice { get; }

        public  Order(string name,int quantity, double price)
        {
            
            Name = name;
            Quantity = quantity;
            TotalPrice = price*quantity;
        }

        //add order to the dictionary with key as customer ssn and order as list of products
        public void AddProductListToDictionart(int ssn,List<Order>customerOrder)
        {
            listsOfAllCustomerOrder.Add(ssn, customerOrder);
        }
        public void Disply(int ssn)
        {
            //display the order list of customer with the id ssn
            List<Order> customerList = listsOfAllCustomerOrder[ssn];
            Console.WriteLine("Heres Your total order:");
            double TotalTotalPrice = 0.0;
            foreach(var order in customerList)
            {
                Console.WriteLine($"{order.Quantity}: {order.Name}  ={order.TotalPrice}");
                TotalTotalPrice += order.TotalPrice;
            }
            Console.WriteLine($"SO your total order Price will be {TotalTotalPrice}");
        }
       

    }
}

