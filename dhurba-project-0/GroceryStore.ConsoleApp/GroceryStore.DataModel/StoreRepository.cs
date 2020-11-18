using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroceryStore.DataModel
{
    public class StoreRepository
    {
        private static DbContextOptions<GroceryStoreContext> _sdbContextOptions;



        public StoreRepository(DbContextOptions<GroceryStoreContext> s_dbContextOptions)
        {
            _sdbContextOptions = s_dbContextOptions;
        }

        public static void AddNewCustomer(int id,string firstname,string lastname)
        {
            var context = new GroceryStoreContext(_sdbContextOptions);
            Customer customer = new Customer();
            {
                customer.CustomerId = id;
                customer.FirstName = firstname;
                customer.LastName = lastname;
                
            }
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public static void searchCustomerByName(string name)
        {
            var context = new GroceryStoreContext(_sdbContextOptions);
            IEnumerable<Customer> aCustomer = context.Customers.Where(x=>x.FirstName==name);
            

        }
       // display all order history of a store location
       public static void OrderHistoryOfStore(string storeId)
        {
            var context = new GroceryStoreContext(_sdbContextOptions);
            var listOfOrderHistory = context.CustomerOrders
                .Include(x => x.OrderItems)
                    .ThenInclude(x=>x.Product)
                .Where(x => x.StoreId == storeId);

            foreach (var order in listOfOrderHistory)
            {
                Console.WriteLine($" {order.OrderId}  {order.OrderItems} {order.OrderDate} ");
            }
        }




    }
}
/*
place orders to store locations for customers
add a new customer
search customers by name
display details of an order
display all order history of a store location
display all order history of a customer*/