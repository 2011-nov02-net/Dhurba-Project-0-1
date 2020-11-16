using System;
using System.Collections.Generic;

#nullable disable

namespace GroceryStore.DataModel
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public string StoreId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
