using System;
using System.Collections.Generic;

#nullable disable

namespace GroceryStore.DataModel
{
    public partial class OrderItem
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual CustomerOrder Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
