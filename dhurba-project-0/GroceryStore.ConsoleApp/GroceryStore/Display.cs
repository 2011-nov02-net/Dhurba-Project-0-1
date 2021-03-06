﻿using GroceryStore.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroceryStore
{
    public class Display
    {
        //method to display all the stores locations
        public static void DisplayStoreList(DbContextOptions<GroceryStoreContext> s_dbContextOptions)
        {
            using  var context = Context.GetContext(s_dbContextOptions);
            var stores = context.Stores;
            foreach(var store in stores)
            {
                Console.WriteLine($"{store.StoreId}: {store.Name}");
            }

        }
        // method to display the product list from the store location customer chose from
        public static void DisplayProductList(DbContextOptions<GroceryStoreContext> s_dbContextOptions, string idOfStore)
        {
            string storeid=idOfStore;

            if (idOfStore =="1" || idOfStore=="2" || idOfStore == "3")
            {
                //changing store id from 1,2 or 3 to store1,store2 or store3. to match the storeid in database
                switch (idOfStore)
                {
                    case "1":
                        storeid = "store1";
                        break;
                    case "2":
                        storeid = "store2";
                        break;
                    case "3":
                        storeid = "store3";
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid number");
                
               
            }
            
            using var context= Context.GetContext(s_dbContextOptions);

            // getting list from inventory stores
            var productList = context.InventoryStores;

            //getting a list of products in inventory store with storeId that the customer choose
           

            var productListForAStore = productList.Include(x=>x.Product).Where(x => x.StoreId==storeid);

            //printing out list of products in console for customer to choose.
            
            foreach(var product in productListForAStore)
            {
                Console.WriteLine($"id: {product.ProductId} Name: {product.Product.Name} Quantity: {product.ProductQuantity} Price:{product.Price}");
            }

            

            
           
        }

        public static void DisplayCustomerOrderItems(DbContextOptions<GroceryStoreContext> s_dbContextOptions,int orderid)
        {
          using  var context = new GroceryStoreContext(s_dbContextOptions);
            var orderitemslist = context.OrderItems;
            var orderItems=orderitemslist
                .Include(x=>x.Product)
                .Where(x => x.OrderId == orderid);
            foreach(var orderitem in orderItems)
            {
                Console.WriteLine($"{orderitem.Product.Name} {orderitem.Quantity}");
            }

        }


    }

   
}
