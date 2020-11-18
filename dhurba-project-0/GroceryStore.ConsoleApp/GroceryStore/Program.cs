
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
                OptionBuilder.LogTo(logStream.Write);
                //using optionBuilder to get option which is used in DBcontext to get the context.
                s_dbContextOptions = OptionBuilder.Options;

                //checking if the customer is in the database or is a new customer
                //if the customer exist, ask to choose from one of the three locations.
                string ssn = Console.ReadLine();
              //  int Ssn = int.Parse(ssn);

                searchForCustomer(ssn);

                //ask for customer info, 9 digit ssn, firstname,lastname

              /*  Console.WriteLine("Please provide your First Name.");
                string firstname = Console.ReadLine();
                Console.WriteLine("Please provide your Last Name.");
                string lastname = Console.ReadLine();                   */


                string idOfStore = Console.ReadLine();

                Display.DisplayProductList(s_dbContextOptions, idOfStore);
                //ask customer to choose product id
                Console.WriteLine("Enter the product id for the product you would like to buy.");
                string productId = Console.ReadLine();
                //ask the customer for the quantity of the product they choose to buy
                Console.WriteLine("enter the quantity of the product you choose to buy.");
                string productQuantity = Console.ReadLine();
                



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
            if (ssn.Length == 9)
            {
                using var context = Context.GetContext(s_dbContextOptions);

                var listOFCustomer = context.Customers.ToList();
                int i;
                for (i = 0; i < listOFCustomer.Count; i++)
                {
                    if (listOFCustomer[i].CustomerId == int.Parse(ssn))
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
                        continue;
                        //Console.WriteLine("You are a new customer! your first name please");

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

        public  void AddCustomerToDatabase(int Ssn, string firstname, string lastname)
        {
            using var context = new GroceryStoreContext(s_dbContextOptions);
            /*   var customer = new Customers();
               {
                   customer.CustomerId = Ssn;
                   customer.FirstName = firstname;
                   customer.LastName = lastname;

               context.Customers.Add(customer);
               context.SaveChanges();
                }*/



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


         }*/

    }
}
