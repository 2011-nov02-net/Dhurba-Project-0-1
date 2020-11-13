using System;
namespace GroceryStore
{
	public class Product {
			public int Id { get; }
			private double _price;
			public double Price {
				get { return _price; }
				set{
					if(value<=0){
					throw new ArgumentOutOfRangeException("Price can't be zero or negative");
					}
					_price = value;
	
				}
			}
			public string Name { get; }
			private int _quantity;

			public int Quantity {
				get { return _quantity; }
				set {
					if (value < 0)
					{
						throw new ArgumentException("Product Quantity cant be negative");
					}
						_quantity = value;
			
					}
			}
	public Product(int id,string name,int quantity, double price)
	{
		Id=id;
		Name=name;
		Quantity=quantity;
		Price = price;
	}
}

}
