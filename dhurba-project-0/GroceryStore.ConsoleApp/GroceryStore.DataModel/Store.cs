using System;
using System.Collections.Generic;

#nullable disable

namespace GroceryStore.DataModel
{
    public partial class Store
    {
        public Store()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public string StoreId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
