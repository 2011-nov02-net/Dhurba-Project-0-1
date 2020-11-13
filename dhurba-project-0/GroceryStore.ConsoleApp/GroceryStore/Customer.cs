using System;
using System.Collections.Generic;

namespace GroceryStore{
	public class Customer
{
		//create a dictionary for collection of customer
		Dictionary<int, string> allCustomer = new Dictionary<int, string>();
	private int Ssn { get; }
	public string FullName { get; }
	

	public Customer(int ssn,string fullname)
	{
		Ssn = ssn;
		FullName = fullname;
		
	}

	
}

}


