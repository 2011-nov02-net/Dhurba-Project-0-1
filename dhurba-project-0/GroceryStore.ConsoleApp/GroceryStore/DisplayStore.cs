using System;
using System.Collections.Generic;
namespace GroceryStore
{
    public class DisplayStore : IDisplay
    {
        public void FormatAndDisplay(List<Store> storeList)
        {
            foreach (var store in storeList)
            {
                //Console.WriteLine($"Id:{store.Id} Name:{store.Name} Location:{store.Location}");
            }
        }

        
    }
}
