
using GroceryStore.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GroceryStore
{
    public class Program
    {
        static DbContextOptions<GroceryStoreContext> s_dbContextOptions;


        static void Main(string[] args)

        {
            Console.WriteLine("Welcome to the  Grocery Store, ");
            Console.WriteLine("press 'Q' to quit");
            Console.WriteLine("To continue-Please provide your 9 digit ssn");

            string Quit = "s";
            

            while (Quit != "q")
            {
                //log in a file groceryLogs.txt
                using var logStream = new StreamWriter("groceryLogs.txt");
                //optionbuilder and useSql server  for c# to connect to the database
                var OptionBuilder = new DbContextOptionsBuilder<GroceryStoreContext>();
                OptionBuilder.UseSqlServer(GetConnectionString());
                //logging to groceryLogs using optionbuilder
                OptionBuilder.LogTo(logStream.Write,LogLevel.Information);
                //using optionBuilder to get option which is used in DBcontext to get the context.
                s_dbContextOptions = OptionBuilder.Options;

                //checking if the customer is in the database or is a new customer
                //if the customer exist, ask to choose from one of the three locations.
                var ssn = Console.ReadLine();
                searchForCustomer(ssn);



                string idOfStore = Console.ReadLine();
             
                Display.DisplayProductList(s_dbContextOptions, idOfStore);


                








               



               
                
               
               
                
               
                

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
            Quit = Console.ReadLine();
            Console.WriteLine("Thank you for visiting!");
           

        }
           
        static string GetConnectionString()
        {
            /*string path = "../../../../../../../../../../connection-string-grocery.json";
           string json;
            try
            {
                json = File.ReadAllText(path);
            }
               
            catch(IOException)
            {
                Console.WriteLine("File path not found");
                throw;
                
            }

            string connection_string = JsonSerializer.Deserialize<string>(json);
            return connection_string;    */
            return "Server=tcp:revature-trainning-2020.database.windows.net,1433;Initial Catalog=GroceryStore;Persist Security Info=False;User ID=dhurba21;Password=Sci00100azure?;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        }
        //see if the customer id already exists in the database
        public static void searchForCustomer(string ssn)
        {
            if (ssn.Length==9) {
               using var context = Context.GetContext(s_dbContextOptions);
               
                var listOFCustomer = context.Customers.ToList();
                int i;
                for ( i=0; i < listOFCustomer.Count; i++)
                {
                    if(listOFCustomer[i].CustomerId== int.Parse(ssn))
                    {
                        Console.WriteLine($"welcome back {listOFCustomer[i].FirstName} ");
                        Console.WriteLine("Which location would you like to shop today from?");
                        Console.WriteLine($"Choose 1 for Store1, 2 for Store2 and 3 for Store3");
                        //display list of stores to choose from.
                        Display.DisplayStoreList(s_dbContextOptions);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You are a new customer! your first name please");
                    }
                }
                /*
                {
                    if (int.Parse(ssn) == customer.CustomerId)
                    {
                        Console.WriteLine($"welcome back {customer.FirstName} ");
                    }
                    else false;
                    {
                        Console.WriteLine("You are a new customer! your first name please");
                    }
                }*/

            }
            else { Console.WriteLine("please provide 9 digit ssn number"); }

           

        }
       /* public static void Display5Track()
        {
            using var context = Context.GetContext(s_dbContextOptions);
            var names = context.Products.Take(3);
            foreach(var x in names)
            {
                Console.WriteLine(x.Name);
            }
            Console.WriteLine(names);
            
           
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



    

