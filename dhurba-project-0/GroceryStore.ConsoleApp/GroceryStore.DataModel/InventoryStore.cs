using System;
using System.Collections.Generic;

#nullable disable

namespace GroceryStore.DataModel
{
    public partial class InventoryStore
    {
        public string StoreId { get; set; }
        public string ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
