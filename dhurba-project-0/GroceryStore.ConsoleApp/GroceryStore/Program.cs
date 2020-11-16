
using GroceryStore.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace GroceryStore
{
    public class Program
    {
        static DbContextOptions<GroceryStoreContext> s_dbContextOptions;


        static void Main(string[] args)

        {
            var OptionBuilder = new DbContextOptionsBuilder<GroceryStoreContext>();
            OptionBuilder.UseSqlServer(connectionString);
            s_dbContextOptions = OptionBuilder.Options;





            Console.WriteLine("Hello World!");
            Console.WriteLine("Welcome back to Dhurba Grocery Store, Are you John, Matt, Jessica or Shayam");
            string customerName = Console.ReadLine();
            Console.WriteLine($"Welcome {customerName}, Nice to see u again. Please choose one of the store (1,2 or 3) that you would like to shop from");

            // display list of store and ask to choose one
            
            //creating an object of class DisplayStore
            DisplayStore myDisplayProduct = new DisplayStore();

            //initializing allStore
            //List<Store> storeList = allStore();

            //calling method of DisplayStore to display list of store
           // myDisplayProduct.FormatAndDisplay(storeList);

            //customer choice of store
            string storeNumber = Console.ReadLine();
           // int storenumber = Int.Parse(storeNumber);
            //display items available at that store
           // List<List<Product>> desiredProduct = allProduct();

            //creating object of class DisplayProduct
            DisplayProduct displayProduct = new DisplayProduct();
            //displayProduct.FormatAndDisplay(desiredProduct, storenumber);
            
         }
        static void GetConnectionString()
        {
            string path = "../../../../../../desktop/connectionStringGrocery";
            string json;
            try
            {
                json = File.ReadAllText(path);
            }
            catch(IOException)
            {

            }
           
        }
/*
        static List<Store> allStore()
        {
            return new List<Store>{
            new Store("1","Store1","Blacklick"),
            new Store("2","Store2","Reynoldsburg" ),
            new Store("3", "Store3","Westerville")
            };
        }
        static List<List<Product>> allProduct()
        {
            return new List<List<Product>>() {
                new List<Product>{
                    new Product("1","Orange",100,1.50),
                    new Product("2","Apple",100,1.0),
                    new Product("3","Mango",100,1.75)
                },
                new List<Product>
                {
                    new Product("1","Orange",100,1.5),
                    new Product("2","Apple",100,1.0),
                    new Product("3","Mango",100,1.75)
                },
                new List<Product>
                {
                    new Product("1","Orange",100,1.5),
                    new Product("2","Apple",100,1.0),
                    new Product("3","Mango",100,1.75)
                }

               

            };

            


           /* return new List<Product>{
                new Product("1","Orange",100),
                new Product("2","Apple",100),
                new Product("3","Mango",100)
            };*/
        }
        /* static Dictionary<Store,List<Product>>allProduct(){
            return List<Product>productList= new List<Product>{
                 new Product("1","Orange",100),
                 new Product("2","Apple",100),
                 new Product("3","Mango",100)
            };
            myDictionary.Add("1",new List<Product>{new Product("1","Orange",100),new Product("2","Apple",100),new Product("3","Mango",100)});
             myDictionary .Add(2,new List<Product>{new Product("1","Orange",100),new Product("2","Apple",100),new Product("3","Mango",100)});
             myDictionary.Add(3,new List<Product>{new Product("1","Orange",100), new Product("2","Apple",100), new Product("3","Mango",100)});

            return myDictionary;
            */

        /* {
              new Product("1","Orange",100),
              new Product("2","Apple",100),
              new Product("3","Mango",100)
          };
         */

    }



    

