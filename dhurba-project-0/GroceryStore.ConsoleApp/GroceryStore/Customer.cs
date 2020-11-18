using System;
using System.Collections.Generic;

namespace GroceryStore{
	public class Customer
{
		//create a dictionary for collection of customer
		Dictionary<int, string> allCustomer = new Dictionary<int, string>();
	private int CustomerId { get; }
	public string FirstName { get; }
	public string LastName { get; }

	public Customer(int ssn,string firstname,string lastname)
	{
			CustomerId = ssn;
			FirstName = firstname;
			LastName =   lastname;
		
	}

	
}

}


