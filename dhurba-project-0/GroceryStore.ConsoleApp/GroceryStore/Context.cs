using GroceryStore.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore
{
    public class Context
    {
       

        public static GroceryStoreContext GetContext(DbContextOptions<GroceryStoreContext>s_dbContextOptions)
        {
            GroceryStoreContext context = new GroceryStoreContext(s_dbContextOptions);
            return context;
        }
    }
   
}
